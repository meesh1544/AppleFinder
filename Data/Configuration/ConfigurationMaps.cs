using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppleFinder.Data.Configuration
{
    internal class ConfigurationMaps : IEntityTypeConfiguration<ConfigurationMaps>
    {
        public void Configure(EntityTypeBuilder<ConfigurationMaps> entity){
            {
                //seed data
                entity.HasData(
                    new {MapId = "FarmStand", Name= "Gallaghers"},
                    new {MapId = "FarmStand", Name = "Friske"},
                    new {MapId = "FarmStand", Name = "King Orchards"},
                    new {MapId = "FarmStand", Name = "Farmer White's"},
                    new {MapId = "FarmStand", Name = "Johnsons Farms Fruit Stand"},
                    new {MapId = "FarmStand", Name = "Groleau Farm Market"},
                    new {MapId = "FarmStand", Name = "Wagner Farms"},
                    new {MapId = "FarmStand", Name = "Youker Farm Market"},
                    new {MapId = "Orchards", Name = "Rennie Farms"},
                    new {MapId = "Orchards", Name = "Bardenhagen Farms"},
                    new {MapId = "Orchards", Name = "Bakker's Acres"},
                    new {MapId = "Orchards", Name = "VerSnyder Orchards"},
                    new {MapId = "Orchards", Name = "Williams Orchard"},
                    new {MapId = "Orchards", Name = "Sleeping Bear Orchards"},
                    new {MapId = "Orchards", Name = "Altonen Orchards"},
                    new {MapId = "Orchards", Name = "InterWater Farms"},
                    new {MapId = "Orchards", Name = "King Orchards"},
                    new {MapId = "Orchards", Name = ""}
                    );
            }
    }
    
    }
}
