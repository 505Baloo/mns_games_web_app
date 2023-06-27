using mns_games_web_app.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mns_games_web_app.Models
{
    public class QuestionVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public TimeSpan? Duration { get; set; }

        public QuizVM Quiz { get; set; }
    }
}
