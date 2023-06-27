using mns_games_web_app.Abstract.Interfaces;
using mns_games_web_app.Data;

namespace mns_games_web_app.Repositories
{
    public class QuestionRepository : BasicRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
