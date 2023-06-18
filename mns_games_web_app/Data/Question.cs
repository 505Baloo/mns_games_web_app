using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mns_games_web_app.Data
{
    public class Question
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public TimeSpan? Duration { get; set; }

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }

        public int QuizId { get; set; }
    }
}
