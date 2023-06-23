using System.ComponentModel.DataAnnotations;

namespace mns_games_web_app.Models.ViewModels
{
    public class ThemeVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(200, ErrorMessage = "Please enter a valid Title")]
        public string Title { get; set; }
    }
}
