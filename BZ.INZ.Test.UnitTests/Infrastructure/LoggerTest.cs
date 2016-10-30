using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using Module = BZ.INZ.Infrastructure.Logger.IoC.Module;
using System.Collections.Generic;
using BZ.INZ.Infrastructure.Logger.Strategies;
using BZ.INZ.Domain.Model.Command;
using Newtonsoft.Json;

namespace BZ.INZ.Test.UnitTests.Infrastructure {
    [TestClass]
    public class LoggerTest {
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
        public void ObfuscationJsonConverterTest() {
            var obfuscationConverter = container.Resolve<ObfuscationJsonConverter>();
            var dataToConvert = new SampleCommandModel { FirstName = "LastName", LastName = "TestName" };
            var convertedObject = JsonConvert.SerializeObject(dataToConvert, Formatting.Indented, obfuscationConverter);
            Assert.IsNotNull(convertedObject);
        }
    }
}
