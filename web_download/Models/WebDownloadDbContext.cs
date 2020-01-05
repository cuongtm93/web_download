using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_download.Models
{
    public class WebDownloadDbContext : DbContext
    {
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Startup.Configuration["ConnectionString"]);
            Database.EnsureCreated();
        }
    }
}
