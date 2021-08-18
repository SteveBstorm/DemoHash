using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Dal.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
