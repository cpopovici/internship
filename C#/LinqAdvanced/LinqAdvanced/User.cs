using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAdvanced
{
    enum UserRole
    {
        Admin,
        User,
        Manager,
        Editor
    };

    class User
    {
        public UserRole Role { get; private set; }
        public int UserID { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public User(string name, string lastname, UserRole role)
        {
            Random random = new Random();
            this.UserID = random.Next(1000, 9999);
            this.Name = name;
            this.LastName = lastname;
            this.Role = role;
        }
    }
}
