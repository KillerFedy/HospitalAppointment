using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Result<User> GetUserByLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
                return Result.Fail<User>("Empty login");

            var user = _repository.GetByLogin(login);

            return user is null ? Result.Fail<User>("User not found") : Result.Ok(user);
        }

        public Result<User> CreateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Login))
                return Result.Fail<User>("Empty login");
            if (string.IsNullOrEmpty(user.Password))
                return Result.Fail<User>("Empty password");

            return Result.Ok<User>(user);
        }

        public Result CheckUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
                return Result.Fail("Empty password");
            if (string.IsNullOrEmpty(password))
                return Result.Fail("Empty password");

            return Result.Ok();
        }
    }
}
