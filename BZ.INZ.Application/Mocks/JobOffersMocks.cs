using BZ.INZ.Domain.Model.Query.Detail;
using System;
using System.Collections.Generic;

namespace BZ.INZ.Application.Mocks {
    public class JobOffersMocks {
        public IEnumerable<JobOffer> MockedData {
            get {
                return new JobOffer[] {
                    new JobOffer { Id = Guid.NewGuid(),Name = "Test1" },
                    new JobOffer { Id = Guid.NewGuid(),Name = "Test2" },
                    new JobOffer { Id = Guid.NewGuid(),Name = "Test3" },
                    new JobOffer { Id = Guid.NewGuid(),Name = "Test4" },
                };
            }

            private set { }
        }
    }
}
