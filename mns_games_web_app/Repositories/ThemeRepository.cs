using mns_games_web_app.Abstract.Interfaces;
using mns_games_web_app.Data;

namespace mns_games_web_app.Repositories
{
    public class ThemeRepository : BasicRepository<Theme>, IThemeRepository
    {
        public ThemeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
