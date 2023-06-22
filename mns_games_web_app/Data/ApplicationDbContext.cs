using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mns_games_web_app.Configurations.Entities;

namespace mns_games_web_app.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Country> Countries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.Country)
                .WithMany(p => p.AppUsers)
                .HasForeignKey(u => u.CountryId);

            modelBuilder.ApplyConfiguration(new CountriesSeedConfiguration());
            modelBuilder.ApplyConfiguration(new RoleSeedConfiguration());
            modelBuilder.ApplyConfiguration(new UserSeedConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleSeedConfiguration());
        }
    }
}