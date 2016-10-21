using Autofac;
using BZ.INZ.Application.Core.Command;
using System.Threading.Tasks;

namespace BZ.INZ.Application.IoC.CommandHandlerInvoker {
    public class CommandHandlerInvoker : ICommandHandlerInvoker {
        private readonly IComponentContext context;

        public CommandHandlerInvoker(IComponentContext context) {
            this.context = context;
        }

        public async Task<ICommandResult> Invoke(ICommand command) {
            var handler = context.ResolveKeyed(command.GetType(), typeof(ICommandHandler));
            return await Invoke(command, handler);
        }

        private async Task<ICommandResult> Invoke(ICommand command, object handler) {
            var handle = handler.GetType().GetMethod("HandleAsync", new[] { command.GetType() });
            var result = handle.Invoke(handler, new[] { command });

            await ((Task)result);
            var value = result.GetType().GetProperty("Result").GetValue(result) as ICommandResult;
            return value;
        }
    }
}
