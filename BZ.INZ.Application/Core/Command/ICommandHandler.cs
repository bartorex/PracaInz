using System.Threading.Tasks;

namespace BZ.INZ.Application.Core.Command {
    public interface ICommandHandler {

    }

    public interface ICommandHandler<in TCommand> where TCommand : ICommand {
        Task Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand, TCommandResult> : ICommandHandler where TCommand : ICommand {
        Task<CommandResult<TCommandResult>> Handle(TCommand command);
    }
}
