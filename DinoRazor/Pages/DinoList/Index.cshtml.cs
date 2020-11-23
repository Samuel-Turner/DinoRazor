using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinoRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DinoRazor.Pages.DinoList
{
    public class IndexModel : PageModel
    {
        private readonly DinoDbContext _db;

        public IndexModel(DinoDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Dino> Dinos { get; set; }
        public async Task OnGet()
        {
            Dinos = await _db.Dino.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var D = await _db.Dino.FindAsync(id);
            if (D != null)
            {
                _db.Dino.Remove(D);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return NotFound();
        }
    }
}
