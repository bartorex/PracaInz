using BZ.INZ.Infrastructure.WebApi.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BZ.INZ.Infrastructure.WebApi.Identity.Context {
    public class ApplicationUserStore : UserStore<ApplicationUser> {
        public ApplicationUserStore(ApplicationDbContext context): base(context) {

        }
    }
}