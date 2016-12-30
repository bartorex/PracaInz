using BZ.INZ.Integration.Core.Gateway;

namespace BZ.INZ.Integration.SomeExternalSystem.Gateway.Request {
    public class ExternalDataRequest : IRequest {
        public string Data { get; set; }
    }
}
