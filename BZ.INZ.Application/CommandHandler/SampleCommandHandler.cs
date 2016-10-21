using System;
using System.Threading.Tasks;
using BZ.INZ.Application.Command.SampleCommand;
using BZ.INZ.Application.Core.Command;

namespace BZ.INZ.Application.CommandHandler {
    public class SampleCommandHandler : ICommandHandler<SampleCommand, SampleCommandResult> {
        public async Task<SampleCommandResult> Handle(SampleCommand command) {
            return await Task.Run(() => {
                return new SampleCommandResult { ResultValue = command.Value }; 
            });
        }
    }
}
