using mns_games_web_app.Data;
using mns_games_web_app.Services;
using System.ComponentModel.DataAnnotations;

namespace mns_games_web_app.Models
{ 
    public class CreateQuizVM
    {
        [Required]
        [Display(Name = "Quiz Name")]
        public string Name { get; set; }

        [Display(Name = "Maximum Duration")]
        public TimeSpan? Duration { get; set; }

        [Required]
        [CustomSelectValidator]
        public int ThemeId { get; set; }
    }
}
