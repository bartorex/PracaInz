using BZ.INZ.Application.Command;
using BZ.INZ.Application.Core.Command;
using BZ.INZ.Domain.Model.Query.Detail;
using BZ.INZ.Infrastructure.Storage.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.INZ.Application.CommandHandler {
    public class DeleteJobOfferCommandHandler : ICommandHandler<DeleteJobOfferCommand, bool> {
        private readonly IUnitOfWork unitOfWork;

        public DeleteJobOfferCommandHandler(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        //public async Task Handle(DeleteJobOfferCommand command) {
        //    var query = await unitOfWork.Query<JobOffer>();
        //    var entity = query.Single(x => x.Id == command.Id);
        //    await unitOfWork.Delete(entity);
        //    await unitOfWork.SaveChangesAsync();
        //}

        public async Task<CommandResult<bool>> Handle(DeleteJobOfferCommand command) {
            var query = await unitOfWork.Query<JobOffer>();
            var entity = query.Single(x => x.Id == command.Id);
            await unitOfWork.Delete(entity);
            await unitOfWork.SaveChangesAsync();
            return new CommandResult<bool> { Value = true }; 
        }
    }
}
