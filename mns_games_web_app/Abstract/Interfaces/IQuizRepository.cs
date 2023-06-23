using mns_games_web_app.Data;
using mns_games_web_app.Models;

namespace mns_games_web_app.Abstract.Interfaces
{
    public interface IQuizRepository : IBasicRepository<Quiz>
    {
        Task<AppUserQuizsVM> GetAppUserQuizs(string userId);
    }
}
