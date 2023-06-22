using System.ComponentModel.DataAnnotations;

namespace mns_games_web_app.Models
{
    public class EditQuizVM
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [Display(Name="Maximum Duration")]
        public TimeSpan? Duration { get; set; }
        
        public int ThemeId { get; set; }

        public string AppUserId { get; set; }
    }
}
