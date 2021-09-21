using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthDemo.Pages
{
    [BindProperties] //binder alla properties
    public class LoginModel : PageModel
    {
        [Required(ErrorMessage = "Username is missing")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is missing")]
        public string Password { get; set; }


        private readonly SignInManager<IdentityUser> SignInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.SignInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(Username, Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Admin/Index");
                }
            }

            return Page();
        }
    }
}
