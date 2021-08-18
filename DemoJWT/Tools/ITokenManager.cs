using DemoJWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoJWT.Tools
{
    public interface ITokenManager
    {
        UserComplete Authenticate(UserComplete user);
    }
}
