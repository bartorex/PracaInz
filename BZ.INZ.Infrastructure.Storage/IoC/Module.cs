using Autofac;
using BZ.INZ.Infrastructure.Storage.Context;
using BZ.INZ.Infrastructure.Storage.UnitOfWork;

namespace BZ.INZ.Infrastructure.Storage.IoC {
    public class Module : Autofac.Module {
        protected override void Load(ContainerBuilder builder) {
            base.Load(builder);

            builder.RegisterType<UnitOfWork.UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationContext>().AsSelf();
        }
    }
}
