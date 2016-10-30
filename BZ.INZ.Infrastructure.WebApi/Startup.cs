using Autofac;
using Autofac.Integration.WebApi;
using BZ.INZ.Infrastructure.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]

namespace BZ.INZ.Infrastructure.WebApi {
    public class Startup {
        private static OAuthAuthorizationServerOptions OAuthOptions { get; set; }

        public void Configuration(IAppBuilder app) {
            HttpConfiguration configuration = new HttpConfiguration();
            var builder = new ContainerBuilder();
            RegisterModule(builder);

            IContainer container = builder.Build();

            WebApiConfig.Register(configuration);
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseWebApi(configuration);
        }

        private void RegisterModule(ContainerBuilder builder) {
            builder.RegisterModule<Integration.DocuSign.IoC.Module>();
            builder.RegisterModule<Application.IoC.Module>();
        }

        private void ConfigureOauth(IAppBuilder app, IContainer container) {

        }
    }
}