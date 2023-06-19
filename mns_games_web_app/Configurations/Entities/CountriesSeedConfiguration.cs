using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mns_games_web_app.Data;
using System.Reflection.Emit;

namespace mns_games_web_app.Configurations.Entities
{
    public class CountriesSeedConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country { Id = 1, Name = "Germany" },
                new Country { Id = 2, Name = "Austria" },
                new Country { Id = 3, Name = "Belgium" },
                new Country { Id = 4, Name = "Bulgaria" },
                new Country { Id = 5, Name = "Cyprus" },
                new Country { Id = 6, Name = "Croatia" },
                new Country { Id = 7, Name = "Danemark" },
                new Country { Id = 8, Name = "Spain" },
                new Country { Id = 9, Name = "Estonia" },
                new Country { Id = 10, Name = "Finland" },
                new Country { Id = 11, Name = "France" },
                new Country { Id = 12, Name = "Greece" },
                new Country { Id = 13, Name = "Hungaria" },
                new Country { Id = 14, Name = "Ireland" },
                new Country { Id = 15, Name = "Italia" },
                new Country { Id = 16, Name = "Lettony" },
                new Country { Id = 17, Name = "Lituania" },
                new Country { Id = 18, Name = "Luxemburg" },
                new Country { Id = 19, Name = "Malta" },
                new Country { Id = 20, Name = "Netherlands" },
                new Country { Id = 21, Name = "Poland" },
                new Country { Id = 22, Name = "Portugal" },
                new Country { Id = 23, Name = "Czech Republic" },
                new Country { Id = 24, Name = "Romania" },
                new Country { Id = 25, Name = "Slovakia" },
                new Country { Id = 26, Name = "Slovenia" },
                new Country { Id = 27, Name = "Sweden" }
            );
        }
    }
}
