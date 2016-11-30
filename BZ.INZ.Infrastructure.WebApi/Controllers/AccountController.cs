using BZ.INZ.Infrastructure.WebApi.Identity.Manager;
using BZ.INZ.Infrastructure.WebApi.Identity.Model;
using BZ.INZ.Infrastructure.WebApi.ViewModel;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace BZ.INZ.Infrastructure.WebApi.Controllers {
    [RoutePrefix("account")]
    public class AccountController : ApiController {
        private readonly ApplicationUserManager userManager;

        public AccountController(ApplicationUserManager userManager) {
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> Register(RegistrationViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser {
                Email = model.Email,
                LockoutEnabled = true,
                UserName = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);
            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result) {
            if (result == null) {
                return InternalServerError();
            }

            if (result.Errors != null) {
                foreach (string error in result.Errors) {
                    ModelState.AddModelError("error", error);
                }
                return BadRequest(ModelState);
            }


            return BadRequest();
        }
    }
}