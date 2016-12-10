using Autofac;
using BZ.INZ.Domain.Model.Command;
using BZ.INZ.Domain.Model.Query.Detail;
using BZ.INZ.Infrastructure.Logger.Strategies;
using System;
using System.Collections.Generic;

namespace BZ.INZ.Infrastructure.Logger.IoC {
    public class Module : Autofac.Module {
        protected override void Load(ContainerBuilder builder) {
            base.Load(builder);

            builder.RegisterType<DefaultObfuscationStrategy>()
                .Keyed<IObfuscationStrategy>(typeof(DefaultObfuscationStrategy));

            builder.RegisterType<ExceptThreeLastCharactersObfuscationStrategy>()
                .Keyed<IObfuscationStrategy>(typeof(ExceptThreeLastCharactersObfuscationStrategy));

            builder.RegisterType<ObfuscationJsonConverter>().AsSelf();

            RegisterLogStrategiest(builder);
        }

        private void RegisterLogStrategiest(ContainerBuilder builder) {
            builder.Register<IDictionary<Type, IDictionary<string, IObfuscationStrategy>>>(ctx => {
                var sampleCommandObfProp = new Dictionary<string, IObfuscationStrategy> {
                    { "FirstName", ctx.ResolveKeyed<IObfuscationStrategy>(typeof(DefaultObfuscationStrategy)) }
                };

                var employerObfuscation = new Dictionary<string, IObfuscationStrategy>{
                    {"Pesel",  ctx.ResolveKeyed<IObfuscationStrategy>(typeof(ExceptThreeLastCharactersObfuscationStrategy)) }
                };

                return new Dictionary<Type, IDictionary<string, IObfuscationStrategy>> {
                    {typeof(SampleCommandModel), sampleCommandObfProp },
                    {typeof(Employer),employerObfuscation }
                };
            });
        }
    }
}
