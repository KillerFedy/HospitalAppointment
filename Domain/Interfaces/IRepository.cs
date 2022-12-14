using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        IEnumerable<User> GetUserList();
        User GetUser(int id);
        void Create(User item);
        void Update(User item);
        void Delete(int id);
        void Save();
    }
}
