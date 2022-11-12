using DataBase.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Converters
{
    public static class UserToDomainConverter
    {
        public static User? ToDomain(this UserModel model)
        {
            return new User(model.Id, model.Login, model.Password, model.PhoneNumber, model.Initials, model.Role);
        }
    }
}
