using BZ.INZ.Infrastructure.WebApi.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BZ.INZ.Infrastructure.WebApi.Identity.Context {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext() {

        }
    }
}