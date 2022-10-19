using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public User GetByLogin(string login);

        public User CreateUser(User user);

        public bool CheckUser(string login, string password);
    }
}
