using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
