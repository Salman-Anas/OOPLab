using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business
{
    class user
    {
        public user(string userName, string password, string role)
        {
            this.userName = userName;
            this.password = password;
            this.role = role;
        }
        public string userName;
        public string password;
        public string role;
    }
}
