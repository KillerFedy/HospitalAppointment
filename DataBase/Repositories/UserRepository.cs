using DataBase.Converters;
using DataBase.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataBase.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool CheckUser(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(u => (u.Login == login && u.Password == password));
            return true;
        }

        public User CreateUser(User user)
        {
            UserModel model = new UserModel
            {
                Id = user.UserId,
                Initials = user.Initials,
                Login = user.Login,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role
            };
            _context.Users.Add(model);
            _context.SaveChangesAsync();
            return user;
        }

        public User GetByLogin(string login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login);
            return user.ToDomain();
        }
    }
}
