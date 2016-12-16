using Autofac;
using Autofac.Extras.NLog;
using BZ.INZ.Application.Command.SampleCommand;
using BZ.INZ.Application.IoC.CommandHandlerInvoker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Module = BZ.INZ.Application.IoC.Module;
using LogModule = BZ.INZ.Infrastructure.Logger.IoC.Module;
using System.Threading;

namespace BZ.INZ.Test.UnitTests.Application {
    [TestClass]
    public class CommandTest {
        private static IContainer container;

        [ClassInitialize]
        public static void SetUp(TestContext context) {
            var builder = new ContainerBuilder();
            builder.RegisterModule<Module>();
            builder.RegisterModule<LogModule>();
            builder.RegisterModule<NLogModule>();
            builder.RegisterModule<SimpleNLogModule>();
            container = builder.Build();
        }

        [TestCleanup]
        public void TearDown() {
            container.Dispose();
        }

        [TestMethod]
        public async Task SampleCommandTest() {
            var invoker = container.Resolve<ICommandHandlerInvoker>();
            var result = await invoker.Invoke(new SampleCommand {
                FirstName = "Test"
            });
            Thread.Sleep(7000);
            Assert.IsNotNull(result);
        }
    }
}
