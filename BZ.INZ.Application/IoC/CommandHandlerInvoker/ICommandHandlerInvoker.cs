using BZ.INZ.Application.Core.Command;
using System.Threading.Tasks;

namespace BZ.INZ.Application.IoC.CommandHandlerInvoker {
    public interface ICommandHandlerInvoker {
        Task<CommandResult> Invoke(ICommand command);
    }
}
