using System;
using System.Threading.Tasks;
using BZ.INZ.Integration.Core.Gateway;
using BZ.INZ.Integration.DocuSign.Gateway.Request;
using BZ.INZ.Integration.DocuSign.Gateway.Response;

namespace BZ.INZ.Integration.DocuSign.Gateway {
    public class Gateway : IGateway<SampleRequest, SampleResponse> {
        public async Task<SampleResponse> CallAsync(SampleRequest request) {
            return await Task.Run(() =>{
                return new SampleResponse();
            });    
        }
    }
}
