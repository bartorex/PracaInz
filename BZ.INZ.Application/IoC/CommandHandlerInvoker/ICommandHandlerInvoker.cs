using BZ.INZ.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.INZ.Application.IoC.CommandHandlerInvoker {
    public interface ICommandHandlerInvoker {
        Task<ICommandResult> Invoke(ICommand command);
    }
}
