using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 6)]
        public string Password { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
    }
}