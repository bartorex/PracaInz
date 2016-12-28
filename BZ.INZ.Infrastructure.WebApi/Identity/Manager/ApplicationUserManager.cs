using BZ.INZ.Infrastructure.WebApi.Identity.Context;
using BZ.INZ.Infrastructure.WebApi.Identity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.DataProtection;

namespace BZ.INZ.Infrastructure.WebApi.Identity.Manager {
    public class ApplicationUserManager : UserManager<ApplicationUser> {
        private readonly ApplicationDbContext context;
        public ApplicationUserManager(
            ApplicationUserStore userStore, 
            IDataProtectionProvider dataProvider, 
            ApplicationDbContext context) 
            : base(userStore){
            this.context = context;
        }
    }
}
