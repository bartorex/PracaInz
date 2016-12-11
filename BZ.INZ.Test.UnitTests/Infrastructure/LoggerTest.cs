using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using Module = BZ.INZ.Infrastructure.Logger.IoC.Module;
using BZ.INZ.Infrastructure.Logger.Strategies;
using BZ.INZ.Domain.Model.Command;
using Newtonsoft.Json;
using BZ.INZ.Domain.Model.Query.Detail;
using System;
using Autofac.Extras.NLog;

namespace BZ.INZ.Test.UnitTests.Infrastructure {
    [TestClass]
    public class LoggerTest {
        private static IContainer container;

        [ClassInitialize]
        public static void SetUp(TestContext context) {
            var builder = new ContainerBuilder();
            builder.RegisterModule<Module>();
            builder.RegisterModule<NLogModule>();
            builder.RegisterModule<SimpleNLogModule>();
            container = builder.Build();
        }

        [ClassCleanup]
        public static void TearDown() {
            container.Dispose();
        }

        [TestMethod]
        public void ObfuscationJsonConverterTest() {
            var obfuscationConverter = container.Resolve<ObfuscationJsonConverter>();
            var dataToConvert = new SampleCommandModel { FirstName = "LastName", LastName = "TestName" };
            var convertedObject = JsonConvert.SerializeObject(dataToConvert, Formatting.Indented, obfuscationConverter);
            Assert.IsNotNull(convertedObject);
        }

        [TestMethod]
        public void ObfuscationJsonConverterWithOnlyThreeNumbers() {
            var obfuscationConverter = container.Resolve<ObfuscationJsonConverter>();
            var dataToConvert = new Employer { Id = Guid.NewGuid(), Pesel = "9301010604" };
            var convertedObject = JsonConvert.SerializeObject(dataToConvert, Formatting.Indented, obfuscationConverter);
            Assert.IsNotNull(convertedObject);
        }

        [TestMethod]
        public void SimpleLogTest() {
            var logger = container.Resolve<ILogger>();
            logger.Info("Test");
        }
    }
}
