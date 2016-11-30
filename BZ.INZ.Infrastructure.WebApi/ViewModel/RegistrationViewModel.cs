using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BZ.INZ.Infrastructure.WebApi.ViewModel {
    public class RegistrationViewModel {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [Display(Name ="Email")]
        [EmailAddress(ErrorMessage ="Invalid email")]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        [Compare("Password",ErrorMessage = "Confirm password doesn't match, Type again!")]
        public string ConfirmPassword { get; set; }
    }
}