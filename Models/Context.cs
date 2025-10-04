using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pirmais_praktiskais_darbs.Models;

namespace pirmais_praktiskais_darbs.Models
{
    class Context : DbContext
    {
        public DbSet<Darbinieks> Darbinieki { get; set; }
        public DbSet<Amats> Amati { get; set; }
        public DbSet<Departaments> Departamenti { get; set; }
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2HA9TKD\\SQLEXPRESS;Database=DarbiniekuInfo;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}
