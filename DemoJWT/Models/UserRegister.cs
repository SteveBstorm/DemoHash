using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoJWT.Models
{
    public class UserRegister
    { 
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
        public DateTime BirthDate { get; set; }

    }

    public class UserLogin
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class UserComplete
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public bool IsAdmin { get; set; }

        public string Token { get; set; }
        public DateTime BirthDate { get; set; }

    }

}
