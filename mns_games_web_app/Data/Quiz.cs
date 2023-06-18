using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mns_games_web_app.Data
{
    public class Quiz
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public TimeSpan? Duration { get; set; }

        [ForeignKey("ThemeId")]
        public Theme Theme { get; set; }
        public int ThemeId { get; set; }

        public string AppUserId { get; set; }

    }
}
