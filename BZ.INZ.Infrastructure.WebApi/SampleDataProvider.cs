using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static BZ.INZ.Infrastructure.WebApi.Controllers.SampleController;

namespace BZ.INZ.Infrastructure.WebApi {
    public class SampleDataProvider {
        public IEnumerable<SampleClass> ProvaideMockData() {
            return new[] {
                new SampleClass { FirstName = "First", LastName = "Last", Id = 1 }
            };
        }
    }
}