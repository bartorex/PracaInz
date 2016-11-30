﻿using BZ.INZ.Application.Core.Query;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BZ.INZ.Infrastructure.WebApi.Controllers.Query {
    [RoutePrefix("samplesQuery")]
    public class SamplesQueryController {
        private readonly IQueryHandlerAsync<string, string> testHandler;
       
        public SamplesQueryController(IQueryHandlerAsync<string,string> testHandler) {
            this.testHandler = testHandler;
        }

        [HttpGet]
        [Route("getTest/{}")]
        private Task<IEnumerable<string>> GetTest(string test) {

        }
    }
}