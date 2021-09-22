using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageUploadDemo.Database;
using ImageUploadDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImageUploadDemo.Pages
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment webHostEnv;

        [BindProperty]
        public DogModel Dog { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

        public EditModel(IWebHostEnvironment webHostEnv)
        {
            this.webHostEnv = webHostEnv;
        }

        public void OnGet(int id)
        {
            Dog = DummyDogRepo.GetDogs().FirstOrDefault(x => x.Id == id);
        }

        public IActionResult OnPost()
        {
            if(Photo != null)
            {
                var folder = Path.Combine(webHostEnv.WebRootPath, "images");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                var file = Path.Combine(folder, Dog.PhotoPath);

                if (System.IO.File.Exists(file))
                    System.IO.File.Delete(file);

                var uniqueFileName = String.Concat(Guid.NewGuid().ToString(), "-", Dog.Name.ToLower(), ".jpg");

                var uploadFolder = Path.Combine(folder, uniqueFileName);

                using (var fileStream = new FileStream(uploadFolder, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }

                DummyDogRepo.Dogs.FirstOrDefault(x => x.Id == Dog.Id).PhotoPath = uniqueFileName;

                return RedirectToPage("/Edit", new { Dog.Id });

            }

            return Page();
        }
    }
}
