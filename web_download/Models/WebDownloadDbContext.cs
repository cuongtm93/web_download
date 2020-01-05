using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_download.Models
{
    public class WebDownloadDbContext : DbContext
    {
        public DbSet<TblSoftware> TblSoftware { get; set; }
        public DbSet<tblTop> TblTop { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Startup.Configuration["ConnectionString"]);
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
