using BZ.INZ.Integration.SomeExternalSystem.Gateway;
using Autofac;

namespace BZ.INZ.Integration.SomeExternalSystem.IoC {
    public class Module : Autofac.Module {
        protected override void Load(ContainerBuilder builder) {
            base.Load(builder);
            builder.RegisterType<ExternalGateway>().AsImplementedInterfaces();
        }
    }
}
