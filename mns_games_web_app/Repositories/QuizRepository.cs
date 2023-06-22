using mns_games_web_app.Abstract.Interfaces;
using mns_games_web_app.Data;

namespace mns_games_web_app.Repositories
{
    public class QuizRepository : BasicRepository<Quiz>, IQuizRepository
    {
        public QuizRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
