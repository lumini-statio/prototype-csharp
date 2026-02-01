using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using prototipo.Database.Models;

namespace prototipo.Database
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        // Register Models...
        public DbSet<AppUser> AppUsers { get; set; }

        // Custom OnModelCreating method

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "1"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Staff",
                    NormalizedName = "STAFF",
                    ConcurrencyStamp = "2"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "Auditor",
                    NormalizedName = "AUDITOR",
                    ConcurrencyStamp = "3"
                },
                new IdentityRole
                {
                    Id = "4",
                    Name = "Developer",
                    NormalizedName = "DEVELOPER",
                    ConcurrencyStamp = "4"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}