using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Biography {get; set;}
        public string Profession {get; set;}
        public ICollection<Photo> Photos { get; set; }        
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
