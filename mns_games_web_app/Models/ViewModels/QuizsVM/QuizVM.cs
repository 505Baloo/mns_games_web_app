using mns_games_web_app.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mns_games_web_app.Models
{
    public class QuizVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Maximum Duration")]
        public TimeSpan? Duration { get; set; }

        [Required]
        public ThemeVM Theme { get; set; }

        [Display(Name = "Creator")]
        public AppUserListVM AppUser { get; set; }
    }
}
