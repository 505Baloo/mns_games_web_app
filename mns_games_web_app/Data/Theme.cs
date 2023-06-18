using System.ComponentModel.DataAnnotations;

namespace mns_games_web_app.Data
{
    public class Theme
    {
        public int Id { get; set; }
        
        [StringLength(200)]
        public string Title { get; set; }
    }
}
