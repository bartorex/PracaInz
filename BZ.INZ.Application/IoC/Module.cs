﻿using Autofac;
using Autofac.Core;
using BZ.INZ.Application.Core.Command;
using BZ.INZ.Application.IoC.Extension;
using System.Linq;

namespace BZ.INZ.Application.IoC {
    public class Module : Autofac.Module {
        protected override void Load(ContainerBuilder builder) {
            base.Load(builder);

            builder.RegisterTypes(ThisAssembly.GetTypes())
                .Where(t => t.ImplementGenericInterface(
                    type => type == typeof(ICommandHandler<,>) || type == typeof(ICommandHandler<>)))
                .As(t => new KeyedService(t.GetInterfaces().Single(i => i.IsGenericType).GetGenericArguments().First(),
                    typeof(ICommandHandler))).AsImplementedInterfaces();

            builder.RegisterType<CommandHandlerInvoker.CommandHandlerInvoker>().AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterTypes(ThisAssembly.GetTypes())
                .Where(t => t.ImplementInterface(typeof(ICommand)))
                .As(t => new KeyedService(t.Name, typeof(ICommand)));                
        }
    }
}
