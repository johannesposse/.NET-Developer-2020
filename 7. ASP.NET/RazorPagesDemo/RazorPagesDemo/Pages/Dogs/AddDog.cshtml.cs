using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Model;

namespace RazorPagesDemo.Pages.Dogs
{
    public class AddDogModel : PageModel
    {
        [BindProperty]
        public DogModel Dog { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Index", new { dogName = Dog.Name});
        }
    }
}
