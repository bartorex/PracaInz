using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BZ.INZ.Infrastructure.WebApi.Identity.Manager {
    public class ApplicationRoleManager : RoleManager<IdentityRole> {
        public ApplicationRoleManager(IRoleStore<IdentityRole,string> roleStore) : base(roleStore) { }
    }
}