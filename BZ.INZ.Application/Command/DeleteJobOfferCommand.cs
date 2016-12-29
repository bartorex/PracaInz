using BZ.INZ.Application.Core.Command;
using System;

namespace BZ.INZ.Application.Command {
    public class DeleteJobOfferCommand : ICommand {
        public Guid Id { get; set; }
    }
}
