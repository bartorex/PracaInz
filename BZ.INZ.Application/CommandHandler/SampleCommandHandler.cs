using System.Threading.Tasks;
using BZ.INZ.Application.Command.SampleCommand;
using BZ.INZ.Application.Core.Command;

namespace BZ.INZ.Application.CommandHandler {
    public class SampleCommandHandler : ICommandHandler<SampleCommand, string> {
        public async Task<CommandResult<string>> Handle(SampleCommand command) {
            return await Task.Run(() => {
                return new CommandResult<string> { Value = command.Value }; 
            });
        }
    }
}