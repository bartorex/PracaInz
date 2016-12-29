using BZ.INZ.Domain.Model.Query.Detail;
using System;
using System.Collections.Generic;

namespace BZ.INZ.Application.Mocks {
    public class JobOffersMocks {
        public IEnumerable<JobOffer> MockedData {
            get {
                return new JobOffer[] {
                    new JobOffer { Id = Guid.NewGuid(),Name = "Test1", DateRequested = DateTime.Now },
                    new JobOffer { Id = Guid.NewGuid(),Name = "Test2", DateRequested = DateTime.Now },
                    new JobOffer { Id = Guid.NewGuid(),Name = "Test3", DateRequested = DateTime.Now },
                    new JobOffer { Id = Guid.NewGuid(),Name = "Test4", DateRequested = DateTime.Now },
                };
            }

            private set { }
        }
    }
}
