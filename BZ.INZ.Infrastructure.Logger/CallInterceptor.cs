using Autofac.Extras.NLog;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BZ.INZ.Infrastructure.Logger {
    public class CallLogInterceptor : IInterceptor {
        private readonly ILogger logger;

        public CallLogInterceptor(ILogger logger) {
            this.logger = logger;
        }

        public void Intercept(IInvocation invocation) {
            var requestDate = DateTime.Now;
            invocation.Proceed();
            object response = null;
            var task = invocation.ReturnValue as Task;
            if(task != null) {
                task.ContinueWith(t => {
                    response = task.GetType().GetProperty("Result").GetValue(task);
                    DateTime responseDate = DateTime.Now;
                    logger.Info("");
                });
            }
        }

        protected virtual string CreateLogString(DateTime requestDt, DateTime responseDt, object response, IInvocation invocation) {
            var sb = new StringBuilder();
            IEnumerable<object> arguments = invocation.Arguments;
            var targetFullName = invocation.TargetType.FullName;

            sb.AppendLine("Request");
            sb.AppendLine(string.Format("Target: {0}",targetFullName));
            sb.AppendLine(string.Format("Date + time: {0}", requestDt));
            if (arguments != null) {
                sb.AppendLine("Arguments: ");
                foreach (var arg in arguments) {
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }
    }
}
