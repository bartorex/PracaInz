using BZ.INZ.Infrastructure.WebApi.Identity.Context;
using BZ.INZ.Infrastructure.WebApi.Identity.Manager;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Threading.Tasks;

namespace BZ.INZ.Infrastructure.WebApi.Identity.Provider {
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider {
        private readonly Func<ApplicationUserManager> userManagerFactory;
        private readonly ApplicationDbContext context;

        public ApplicationOAuthProvider(
            Func<ApplicationUserManager> userManagerFactory,
            ApplicationDbContext context) {
            this.context = context;
            this.userManagerFactory = userManagerFactory;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {
            try {
                var userManager = userManagerFactory();
                var user = await userManager.FindByNameAsync(context.UserName);
                if(user == null) {
                    context.SetError("invalid_grant","The user name or password is incorrect.");
                    return;
                }

                if (user.UserLocked) {
                    context.SetError("invalid_grant", "Your account has been disabled.");
                    return;
                }

                var validCredentials = await userManager.FindAsync(context.UserName,context.Password);
                if(validCredentials == null) {
                    context.SetError("invalid_credentials", "The username or password is incorrect.");
                }

                var oAuthIdentity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                context.Validated(oAuthIdentity);
                context.Request.Context.Authentication.SignIn(oAuthIdentity);
            } catch(Exception exp) {
                context.SetError("Exception_other", exp.Message);
            };
        }
    }
}