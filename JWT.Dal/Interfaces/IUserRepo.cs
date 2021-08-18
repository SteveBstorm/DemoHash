using JWT.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Dal.Interfaces
{
    public interface IUserRepo : IRepository<User, Guid>
    {
        User Login(string Email, string password);
    }
}
