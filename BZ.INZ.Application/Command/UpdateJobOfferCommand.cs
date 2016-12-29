using BZ.INZ.Application.Core.Command;
using BZ.INZ.Domain.Model.Query.Detail;

namespace BZ.INZ.Application.Command {
    public class UpdateJobOfferCommand : ICommand {
        public JobOffer JobOffer { get; set; }
    }
}
