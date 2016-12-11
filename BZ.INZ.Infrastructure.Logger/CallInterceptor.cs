using Castle.DynamicProxy;
using Autofac.Extras.NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BZ.INZ.Infrastructure.Logger {
    public class CallLogInterceptor : IInterceptor {
        private readonly ILogger logger;
        private readonly LogObfuscator logObfuscator;
        public CallLogInterceptor(ILogger logger, LogObfuscator logObfuscator) {
            this.logger = logger;
            this.logObfuscator = logObfuscator;
        }

        public void Intercept(IInvocation invocation) {
            var requestDate = DateTime.Now;
            invocation.Proceed();
            object response = null;
            var task = invocation.ReturnValue as Task;
            if (task != null) {
                task.ContinueWith(t => {
                    response = task.GetType().GetProperty("Result").GetValue(task);
                    DateTime responseDate = DateTime.Now;
                    logger.Info(CreateLogString(requestDate, responseDate, response, invocation));
                }).ContinueWith(t => {
                    if (t.Exception != null)
                        logger.Log(NLog.LogLevel.Error, t.Exception.Message, t.Exception);
                }, TaskContinuationOptions.OnlyOnFaulted);
            } else {
                try {
                    response = invocation.ReturnValue;
                }catch(Exception exc) {
                    response = exc;
                } finally {
                    DateTime responseDate = DateTime.Now;
                    logger.Info(CreateLogString(requestDate, responseDate, response, invocation));
                }
            }
        }

        public virtual string CreateLogString(DateTime requestDt, DateTime responseDt, object response, IInvocation invocation) {
            var sb = new StringBuilder();
            IEnumerable<object> arguments = invocation.Arguments;
            var targetFullName = invocation.TargetType.FullName;

            sb.AppendLine("Request");
            sb.AppendLine(string.Format("Target: {0}",targetFullName));
            sb.AppendLine(string.Format("Date + time: {0}", requestDt));
            if (arguments != null) {
                sb.AppendLine("Arguments: ");
                foreach (var arg in arguments) {
                    sb.AppendLine(logObfuscator.Obfuscation(arg));
                }
            }

            if(response != null) {
                sb.AppendLine("Result");
                sb.Append("Type: ");
                sb.AppendLine(logObfuscator.Obfuscation(response));
            }

            return sb.ToString();
        }
    }
}
