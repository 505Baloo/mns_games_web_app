using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mns_games_web_app.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "23d2f4de-bc3f-4fdc-eaed-e8231005f4bb", 
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "15d2b4dd-bc5f-4fcc-baed-e8290805f4cb",
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
