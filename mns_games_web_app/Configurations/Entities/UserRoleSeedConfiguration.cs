using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mns_games_web_app.Configurations.Entities
{
    internal class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "23d2f4de-bc3f-4fdc-eaed-e8231005f4bb",
                    UserId = "23d0f9de-bc4f-1fdc-eaed-e9312905f4bb"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "15d2b4dd-bc5f-4fcc-baed-e8290805f4cb",
                    UserId = "40df79cc-c203-472b-ac45-53d7b01be4ab"
                }
            );
        }
    }
}