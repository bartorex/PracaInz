using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace BZ.INZ.Infrastructure.WebApi.Controllers {
    [RoutePrefix("sample")]
    public class SampleController : ApiController {
        private IEnumerable<SampleClass> sampleData { get; set; }

        public SampleController(SampleDataProvider provider) {
            sampleData = provider.ProvaideMockData();
        }

        //public SampleController() {
        //    sampleData = new List<SampleClass> {
        //        new SampleClass {FirstName ="asd", LastName  = "asda", Id = 1 },
        //        new SampleClass {FirstName ="asd", LastName  = "asda", Id = 2 }
        //    };
        //}

        [HttpGet]
        [Route("sampleGet")]
        public async Task<IEnumerable<SampleClass>> SampleGet() {
            return await Task.Run(() => {
                return sampleData;
            });
        }

        public class SampleClass {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Id { get; set; }
        }
    }
}