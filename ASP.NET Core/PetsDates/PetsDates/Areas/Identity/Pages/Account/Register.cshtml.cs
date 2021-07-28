using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetsDates.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static PetsDates.Data.DataConstants;

namespace PetsDates.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
   

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)

        {
            _userManager = userManager;
            _signInManager = signInManager;
 
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(
                UserNameMaxLenght,
                MinimumLength = UserNameMinLenght,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(
                UserNameMaxLenght,
                MinimumLength = UserNameMinLenght,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;      
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new User 
                { 
                    FirtsName = Input.FirstName,
                    LastName = Input.LastName,
                    UserName = Input.Email, 
                    Email = Input.Email
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
               

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
