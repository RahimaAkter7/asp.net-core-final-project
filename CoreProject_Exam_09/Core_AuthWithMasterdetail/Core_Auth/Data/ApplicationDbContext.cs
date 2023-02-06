using Core_Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core_Auth.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<PlantSize> plantSizes { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<pot> pots { get; set; }
        public DbSet<StockEntry> stockEntries { get; set; }
    }

}
