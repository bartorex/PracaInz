using BZ.INZ.Integration.SomeExternalSystem.Gateway.Request;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.INZ.Integration.SomeExternalSystem.Gateway.Client {
    public class Client {
        public void Connect() {

        }

        public ExternalDataResponse GetData(ExternalDataRequest request) {
            return new ExternalDataResponse();
        }
    }
}
