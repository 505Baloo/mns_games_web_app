using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mns_games_web_app.Data
{
    public class AppUser : IdentityUser
    {
        [StringLength(32)]
        public string Nickname { get; set; }

        [StringLength(64)]
        public string? FirstName { get; set; }
        
        [StringLength(64)]
        public string? LastName { get; set; }

        public bool IsAdmin { get; set; }

        [StringLength(64)]
        public string? StreetName { get; set; }

        [StringLength(50)]
        public string? StreetNumber { get; set; }

        [StringLength(50)]
        public string? ZipCode { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [ForeignKey("CountryId")]
        public Country? Country { get; set; }
        public int? CountryId { get; set; }

        public DateTime DateJoined { get; set; }
    }
}
