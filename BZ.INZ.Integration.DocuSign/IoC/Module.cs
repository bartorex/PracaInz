using Autofac;

namespace BZ.INZ.Integration.DocuSign.IoC {
    public class Module : Autofac.Module {
        public string IntegrationKey { get; set; }

        protected override void Load(ContainerBuilder builder) {
            base.Load(builder);

            builder.RegisterType<Gateway.Gateway>().AsImplementedInterfaces();
        }
    }
}
