using mns_games_web_app.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace mns_games_web_app.Models.ViewModels
{ 
    public class CreateQuizVM
    {
        [Required]
        [Display(Name = "Quiz Name")]
        public string Name { get; set; }

        [Display(Name = "Maximum Duration")]
        public TimeSpan? Duration { get; set; }

        public int ThemeId { get; set; }
    }
}
