using System.Threading.Tasks;

namespace BZ.INZ.Application.Core.Command {
    public interface ICommandHandler {

    }

    public interface ICommandHandler<in TCommand, TCommandResult> : ICommandHandler where TCommand : ICommand {
        Task<TCommandResult> Handle(TCommand command);
    }
}
