using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserUpdateDto
    {
        public string Biography { get; set; }
        public string Skills { get; set; }
        public string Profession { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}