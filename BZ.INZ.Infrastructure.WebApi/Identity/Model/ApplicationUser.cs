using Microsoft.AspNet.Identity.EntityFramework;

namespace BZ.INZ.Infrastructure.WebApi.Identity.Model {
    public class ApplicationUser : IdentityUser {
        public bool UserLocked { get; set; }
    }
}