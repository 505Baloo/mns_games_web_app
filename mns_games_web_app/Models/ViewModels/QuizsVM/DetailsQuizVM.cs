﻿using mns_games_web_app.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace mns_games_web_app.Models
{
    public class DetailsQuizVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Maximum Duration")]
        public TimeSpan? Duration { get; set; }

        public Theme Theme { get; set; }

        public AppUser AppUser { get; set; }
    }
}
