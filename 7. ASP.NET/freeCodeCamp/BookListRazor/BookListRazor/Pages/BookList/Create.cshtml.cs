using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly DbCon dbCon;

        public CreateModel(DbCon db)
        {
            this.dbCon = db;
        }

        [BindProperty]public Book Book { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await dbCon.Book.AddAsync(Book);
                await dbCon.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
