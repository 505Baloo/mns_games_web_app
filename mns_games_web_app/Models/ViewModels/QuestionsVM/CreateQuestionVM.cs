using System.ComponentModel.DataAnnotations;

namespace mns_games_web_app.Models
{
    public class CreateQuestionVM
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public TimeSpan? Duration { get; set; }

        [Required]
        public int QuizId { get; set; }
    }
}
