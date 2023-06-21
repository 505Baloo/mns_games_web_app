using mns_games_web_app.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mns_games_web_app.Models.ViewModels
{
    public class QuizVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Maximum Duration")]
        public TimeSpan? Duration { get; set; }

        public Theme Theme { get; set; }
    }
}
