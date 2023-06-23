using System.ComponentModel.DataAnnotations;

namespace mns_games_web_app.Models
{
    public class AppUserListVM
    {
        public string Id { get; set; }

        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        [Display(Name = "User since")]
        public DateTime DateJoined { get; set; }
    }
}
