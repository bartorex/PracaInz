using BZ.INZ.Application.Core.Command;
using BZ.INZ.Domain.Model.Query.Detail;

namespace BZ.INZ.Application.Command.SampleCommand {
    public class CreateJobOfferCommand : ICommand{
        public JobOffer JobOffer { get; set; }
    }
}
