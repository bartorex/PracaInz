using Autofac;
using Autofac.Extras.NLog;
using BZ.INZ.Infrastructure.Storage.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Module = BZ.INZ.Infrastructure.Storage.IoC.Module;
using QueryDomain = BZ.INZ.Domain.Model.Query;

namespace BZ.INZ.Test.UnitTests.Infrastructure {
    [TestClass]
    public class StorageTest {
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
        public async Task AddJobOfferTest() {
            var unitOfWork = container.Resolve<IUnitOfWork>();
            await unitOfWork.Add<QueryDomain.Detail.JobOffer>(new QueryDomain.Detail.JobOffer {
                Content = "SampleContent",
                EmployerId = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                Name = "SampleTitle"
            });

            await unitOfWork.SaveChangesAsync();
        }
    }
}
