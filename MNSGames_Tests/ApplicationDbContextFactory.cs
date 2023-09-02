using Microsoft.EntityFrameworkCore;
using mns_games_web_app.Data;

namespace MNSGames_Tests
{
    public class ApplicationDbContextFactory
    {
        public static ApplicationDbContext CreateDbContextForInMemory()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
