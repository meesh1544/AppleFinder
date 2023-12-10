using AppleFinder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppleFinder.Data.Configuration
{
    internal class ConfigurationApples: IEntityTypeConfiguration<Apples>
    {
        public void Configure(EntityTypeBuilder<Apples> entity) 
        {
            //seed data apples
            entity.HasData(
            new { AppleId = 1, AppleName = "Mackintosh" },
            new { AppleId = 2, AppleName = "Fugi" },
            new { AppleId = 3, AppleName = "Braeburn" },
            new { AppleId = 4, AppleName = "Cortland" },
            new { AppleId = 5, AppleName = "Empire" },
            new { AppleId = 6, AppleName = "EverCrisp" },
            new { AppleId = 7, AppleName = "Gala" },
            new { AppleId = 8, AppleName = "Golden Delicious" },
            new { AppleId = 9, AppleName = "Honeycrisp" },
            new { AppleId = 10, AppleName = "Ida Red" },
            new { AppleId = 11, AppleName = "Jonagold" },
            new { AppleId = 12, AppleName = "Jonathan" },
            new { AppleId = 13, AppleName = "Northern Spy" },
            new { AppleId = 14, AppleName = "Paula Red" },
            new { AppleId = 15, AppleName = "Red Delicious" },
            new { AppleId = 16, AppleName = "Sweet Tango"},
            new { AppleId = 16, AppleName = "" }
            );
        }
    }
}
