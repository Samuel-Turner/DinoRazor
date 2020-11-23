using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinoRazor.Model
{
    public class DinoDbContext : DbContext
    {
        public DinoDbContext(DbContextOptions<DinoDbContext> opt) : base(opt)
        {

        }
        public DbSet<Dino> Dino { get; set; }
    }
}
