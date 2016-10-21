using Autofac;
using BZ.INZ.Integration.Core.Gateway;
using BZ.INZ.Integration.DocuSign.Gateway.Request;
using BZ.INZ.Integration.DocuSign.Gateway.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Module = BZ.INZ.Integration.DocuSign.IoC.Module;

namespace BZ.INZ.Test.UnitTests.Integration {
    [TestClass]
    public class DocuSign {
        private static IContainer container;

        [ClassInitialize]
        public static void SetUp(TestContext context) {
            var builder = new ContainerBuilder();
            builder.RegisterModule<Module>();
            container = builder.Build();
        }

        [ClassCleanup]
        public static void TearDown() {
            container.Dispose();
        }

        [TestMethod]
        public async Task SampleGatewayTest() {
            var gateway = container.Resolve<IGateway<SampleRequest, SampleResponse>>();
            var response = await gateway.CallAsync(new SampleRequest());
            Assert.IsNotNull(response);
        }
    }
}
