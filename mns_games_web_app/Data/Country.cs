using System.ComponentModel.DataAnnotations;

namespace mns_games_web_app.Data
{
    public class Country
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<AppUser>? AppUsers { get; set; }
    }
}
