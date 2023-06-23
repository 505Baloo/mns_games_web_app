using mns_games_web_app.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mns_games_web_app.Models
{
    public class QuizVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Maximum Duration")]
        public TimeSpan? Duration { get; set; }

        public Theme Theme { get; set; }

        [Display(Name = "Creator")]
        public AppUser AppUser { get; set; }
    }
}
