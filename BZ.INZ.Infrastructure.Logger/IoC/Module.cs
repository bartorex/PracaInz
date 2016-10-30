using Autofac;
using BZ.INZ.Infrastructure.Logger.Strategies;

namespace BZ.INZ.Infrastructure.Logger.IoC {
    public class Module : Autofac.Module {
        protected override void Load(ContainerBuilder builder) {
            base.Load(builder);

            builder.RegisterType<DefaultObfuscationStrategy>()
                .Keyed<IObfuscationStrategy>(typeof(DefaultObfuscationStrategy));
        }
    }
}
