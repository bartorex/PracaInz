using Autofac;
using BZ.INZ.Application.Command.SampleCommand;
using BZ.INZ.Application.IoC.CommandHandlerInvoker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Module = BZ.INZ.Application.IoC.Module;

namespace BZ.INZ.Test.UnitTests.Application {
    [TestClass]
    public class CommandTest {
        private static IContainer container;

        [ClassInitialize]
        public static void SetUp(TestContext context) {
            var builder = new ContainerBuilder();
            builder.RegisterModule<Module>();
            container = builder.Build();
        }

        [TestCleanup]
        public static void TearDown() {
            container.Dispose();
        }

        [TestMethod]
        public async Task SampleCommandTest() {
            var invoker = container.Resolve<ICommandHandlerInvoker>();
            var result = await invoker.Invoke(new SampleCommand {
                Value = "sdas"
            });
        };
    }
}
