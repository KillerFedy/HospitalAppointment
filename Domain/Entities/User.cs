using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int UserId { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Initials { get; private set; }
        public UserRole Role { get; private set; }

        public User(int id, string login, string password, string phonenumber, string init, UserRole role)
        {
            UserId = id;
            Login = login;
            Password = password;
            PhoneNumber = phonenumber;
            Initials = init;
            Role = role;
        }
    }
}
