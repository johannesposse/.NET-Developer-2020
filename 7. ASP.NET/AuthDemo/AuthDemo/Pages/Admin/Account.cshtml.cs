using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthDemo.Pages.Admin
{
    [BindProperties]
    public class AccountModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }


        public AccountModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await signInManager.UserManager.GetUserAsync(HttpContext.User);
                var oldPasswordOk = await signInManager.UserManager.CheckPasswordAsync(user, OldPassword);


                var validator = new PasswordValidator<IdentityUser>();
                var result = await validator.ValidateAsync(signInManager.UserManager, user, NewPassword);

                if(oldPasswordOk && result.Succeeded)
                {
                   await signInManager.UserManager.ChangePasswordAsync(user, OldPassword, NewPassword);
                   return RedirectToPage("/Admin/Index");
                }
            }

            return Page();
        }
    }
}
