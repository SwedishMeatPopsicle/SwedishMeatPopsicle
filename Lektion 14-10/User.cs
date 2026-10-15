using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_14_10
{
    public class User
    {
        public string ID { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User(string id, string password, bool isadmin)
        {
            ID = id;
            Password = password;
            IsAdmin = isadmin;
        }
    }
}
