using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSettings
{
    public interface IUserService
    {
        string GetUserName();
        void SetUserName(string newUserName);
    }
}
