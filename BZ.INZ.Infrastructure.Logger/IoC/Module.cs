﻿using Autofac;
using BZ.INZ.Domain.Model.Command;
using BZ.INZ.Infrastructure.Logger.Strategies;
using System;
using System.Collections.Generic;

namespace BZ.INZ.Infrastructure.Logger.IoC {
    public class Module : Autofac.Module {
        protected override void Load(ContainerBuilder builder) {
            base.Load(builder);

            builder.RegisterType<DefaultObfuscationStrategy>()
                .Keyed<IObfuscationStrategy>(typeof(DefaultObfuscationStrategy));

            builder.RegisterType<ExceptThreLastCharactersObfuscationStrategy>()
                .Keyed<IObfuscationStrategy>(typeof(ExceptThreLastCharactersObfuscationStrategy));

            builder.RegisterType<ObfuscationJsonConverter>().AsSelf();

            RegisterLogStrategiest(builder);
        }

        private void RegisterLogStrategiest(ContainerBuilder builder) {
            builder.Register<IDictionary<Type, IDictionary<string, IObfuscationStrategy>>>(ctx => {
                var sampleCommandObfProp = new Dictionary<string, IObfuscationStrategy> {
                    { "FirstName", ctx.ResolveKeyed<IObfuscationStrategy>(typeof(DefaultObfuscationStrategy)) }
                };

                return new Dictionary<Type, IDictionary<string, IObfuscationStrategy>> {
                    {typeof(SampleCommandModel), sampleCommandObfProp }
                };
            });
        }
    }
}
