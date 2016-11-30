using Autofac;
using Autofac.Integration.WebApi;
using BZ.INZ.Infrastructure.WebApi;
using BZ.INZ.Infrastructure.WebApi.Identity.Context;
using BZ.INZ.Infrastructure.WebApi.Identity.Manager;
using BZ.INZ.Infrastructure.WebApi.Identity.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]

namespace BZ.INZ.Infrastructure.WebApi {
    public class Startup {
        private static OAuthAuthorizationServerOptions OAuthOptions { get; set; }

        public void Configuration(IAppBuilder app) {
            var config = new HttpConfiguration();
            var builder = new ContainerBuilder();
            builder.RegisterType<SampleDataProvider>().AsSelf();
            config.Routes.MapHttpRoute(
               "DefaultApi",
               "api/{controller}/{id}",
               new { id = RouteParameter.Optional });

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterModule(builder);
            RegisterOauthComponents(builder);

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //WebApiConfig.Register(config);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }

        private void RegisterModule(ContainerBuilder builder) {
            builder.RegisterModule<Integration.DocuSign.IoC.Module>();
            builder.RegisterModule<Storage.IoC.Module>();
            builder.RegisterModule<Application.IoC.Module>();
        }

        private void RegisterOauthComponents(ContainerBuilder builder) {
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationUserStore>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationUserStore>().AsSelf().InstancePerLifetimeScope();

            builder.Register<Func<ApplicationUserManager>>(c => {
                var ctx = c.Resolve<IComponentContext>();
                return () => 
                    new ApplicationUserManager(new ApplicationUserStore(new ApplicationDbContext()), c.Resolve<IDataProtectionProvider>(),new ApplicationDbContext());
            });

            builder.RegisterType<ApplicationOAuthProvider>().AsSelf().InstancePerLifetimeScope();
        }

        private void ConfigureOauth(IAppBuilder app, IContainer container) {
            OAuthOptions = new OAuthAuthorizationServerOptions {
                TokenEndpointPath = new PathString("/oauth/token"),
                Provider = container.Resolve<ApplicationOAuthProvider>(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10),
                AllowInsecureHttp = true
            };
        }
    }
}