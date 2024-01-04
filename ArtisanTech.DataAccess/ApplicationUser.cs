using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ArtisanTech.DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string? Address { get; set; }

        public string? PostalCode { get; set; }

    }
}
