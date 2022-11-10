﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class UserModel
    {
        public int UserId { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Initials { get; private set; }
        public UserRole Role { get; private set; }
    }
}