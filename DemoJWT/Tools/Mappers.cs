using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL = JWT.Dal.Models;
using LOCAL = DemoJWT.Models;

namespace DemoJWT.Tools
{
    public static class Mappers
    {
        public static LOCAL.UserComplete toLocal(this DAL.User u)
        {
            return new LOCAL.UserComplete
            {
                Id = u.Id,
                Email = u.Email,
                IsAdmin = u.IsAdmin,
                Username = u.Username,
                BirthDate = u.BirthDate
            };
        }
    }
}
