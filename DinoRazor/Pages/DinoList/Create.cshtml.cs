using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinoRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DinoRazor.Pages.DinoList
{
    public class CreateModel : PageModel
    {
        private readonly DinoDbContext _db;
        public CreateModel(DinoDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Dino Dino { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Dino.AddAsync(Dino);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage("Create");
            }

        }
    }
}
