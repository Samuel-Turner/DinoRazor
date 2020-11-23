using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinoRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DinoRazor.Controllers
{
    [Route("api/Dino")]
    [ApiController]
    public class DinoController : Controller
    {
        private readonly DinoDbContext _db;

        public DinoController(DinoDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new {data =await _db.Dino.ToListAsync()});
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var D = await _db.Dino.FirstOrDefaultAsync(u => u.Id == id);
            if (D != null)
            {
                _db.Dino.Remove(D);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Delete successful" });
            }
            return Json(new { success = false, message = "Error while Deleting" });
        }
         
    }
}
