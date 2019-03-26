using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSettings
{
    public class UserSevice : IUserService
    {
        public string UserName { get; set; }

        public string GetUserName() => UserName;

        public void SetUserName(string newUserName)
        {
            this.UserName = newUserName;
        }
    }
}
