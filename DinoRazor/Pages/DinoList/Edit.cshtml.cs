using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinoRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DinoRazor.Pages.DinoList
{
    public class EditModel : PageModel
    {
        private DinoDbContext _db;

        public EditModel(DinoDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Dino Dino { get; set; }
        
        public async Task OnGet(int id)
        {
            Dino = await _db.Dino.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var D = await _db.Dino.FindAsync(id);
                D.Name = Dino.Name;
                D.Period = Dino.Period;
                D.Diet = Dino.Diet;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage("Edit");
            }
        }
    }
}
