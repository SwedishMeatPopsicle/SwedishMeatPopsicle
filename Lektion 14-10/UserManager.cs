using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_14_10
{
    internal class UserManager
    {
        private List<User> users;
        public void AddUser(User user)
        {
            users.Add(user);
        }
        
        public void ShowUsers()
        {
            foreach (User user in users)
            {
                Console.WriteLine($"{user.ID} {user.Password} {user.IsAdmin}");
            }
        }
    }
}
