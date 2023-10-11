using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppleFinder.Models;

namespace AppleFinder.Models
{
    public class AppleContext : DbContext
    {
        public AppleContext(DbContextOptions<AppleContext> options) : base (options)
        { }
        public DbSet<Members> Membership { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Members>().HasData(
                new Members {
                    ID = 1,
                    FirstName = "Michelle",
                    LastName = "Beckett",
                    Email = "mbeckett@nmc.edu"
                },
                new Members
                {
                    ID = 2,
                    FirstName = "Harry",
                    LastName = "Henderson"
                },
                new Members
                {
                    ID= 3,
                    FirstName = "Bugs",
                    LastName = "Bunny"
                }
                
                );
        }

        public DbSet<AppleFinder.Models.Apples>? Apples { get; set; }

        public DbSet<AppleFinder.Models.Map>? Map { get; set; }

        public DbSet<AppleFinder.Models.Orchard>? Orchard { get; set; }
    }
}
