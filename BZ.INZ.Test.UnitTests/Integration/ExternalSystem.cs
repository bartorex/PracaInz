using Autofac;
using BZ.INZ.Integration.Core.Gateway;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Request;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Module = BZ.INZ.Integration.SomeExternalSystem.IoC.Module;

namespace BZ.INZ.Test.UnitTests.Integration {
    [TestClass]
    public class ExternalSystem {
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
        public async Task ExtenalRequestTest() {
            var gateway = container.Resolve<IGateway<ExternalDataRequest, ExternalDataResponse>>();
            var response = await gateway.CallAsync(new ExternalDataRequest { Data = "TestData" });
            Assert.IsNotNull(response);
        }
    }
}
