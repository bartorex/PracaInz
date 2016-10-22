using Autofac;
using BZ.INZ.Application.Core.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using Module = BZ.INZ.Application.IoC.Module;

namespace BZ.INZ.Test.UnitTests.Application {
    [TestClass]
    public class QueryTest {
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
        public async Task SampleHandlerTest() {
            var handler = container.Resolve<IQueryHandlerAsync<string, string>>();
            var result = await handler.QueryAsync("TestResult");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.First() == "TestResult");
        }
    }
}
