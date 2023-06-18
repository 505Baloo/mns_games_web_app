using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mns_games_web_app.Data
{
    public class Answer
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public bool IsCorrect { get; set; }

        public int? Points { get; set; }

        public int? NextQuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
