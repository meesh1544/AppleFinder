﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppleFinder.Models;

namespace AppleFinder.Models
{
    public class AppleContext : DbContext
    {
        public AppleContext(DbContextOptions<AppleContext> options) : base(options)
        { }
        public DbSet<Members> ?Membership { get; set; } 
        public DbSet<Apples> ?Apples { get; set; }

        public DbSet<Map> ?Map { get; set; }

        public DbSet<AppleFinder.Models.Orchard>? Orchard { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Members>().HasData(
                new Members {
                    ID = 1,
                    FirstName = "Michelle",
                    LastName = "Beckett",
                    Address= "19878 Maple Glade Ln",
                    City = "Lake Ann",
                    State = "MI",
                    Email = "mbeckett@nmc.edu",
                    Zip = "49970",
                    Cell = "231-357-1640"
                },
                new Members
                {
                    ID = 2,
                    FirstName = "Harry",
                    LastName = "Henderson",
                    Address= "1887 Forest Ln",
                    City = "Nowhere",
                    State ="Ak",
                    Email = "hhenderson@gmail.com",
                    Zip = "45987",
                    Cell = "765-441-0032"

                },
                new Members
                {
                    ID = 3,
                    FirstName = "Bugs",
                    LastName = "Bunny",
                    Address= "1887 Hop Ln",
                    City = "Carrot",
                    State ="WY",
                    Email = "bbunny43@gmail.com",
                    Zip = "49684",
                    Cell = "887-995-2201"
                }

                ); ;
        }

       
    }
}
