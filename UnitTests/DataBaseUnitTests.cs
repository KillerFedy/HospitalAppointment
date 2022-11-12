using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DataBase.Models;
using DataBase.Repositories;
using Microsoft.EntityFrameworkCore;
using DataBase;

namespace UnitTests
{
    public class DataBaseUnitTests
    {
        private readonly DbContextOptionsBuilder<ApplicationContext> _optionsBuilder;

        public DataBaseUnitTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(
                $"Host=localhost;Port=5432;Database=yuy;Username=KillerFedy;Password=281103@QWas");
            _optionsBuilder = optionsBuilder;
        }

        /// <summary>
        /// Просто реально добавили запись в БД и проверили, добавилось ли
        /// </summary>
        [Fact]
        public void PlaygroundMethod1()
        {
            using var context = new ApplicationContext(_optionsBuilder.Options);
            context.Users.Add(new UserModel
            {
                Id = 123,
                Login = "DarkLand",
                Password = "23123132",
                PhoneNumber = "88005553535",
                Initials = ";)))))))))))"
            });
            context.SaveChanges(); // сохранили в БД

            Assert.True(context.Users.Any(u => u.Login == "DarkLand")); // проверим, нашло ли в нашей бд

            // Можно например написать такой тест, где мы просто сохранили запись,
            // а потом пойти руками в СУБД посмотреть и убедиться самим, что она там есть 
        }

        /// <summary>
        /// Просто реально удалили запись в БД и проверили, удалилось ли
        /// </summary>
        [Fact]
        public void PlaygroundMethod2()
        {
            using var context = new ApplicationContext(_optionsBuilder.Options);
            var u = context.Users.FirstOrDefault(u => u.Login == "DarkLand");
            context.Users.Remove(u);
            context.SaveChanges(); // удалили в БД

            Assert.True(!context.Users.Any(u => u.Login == "DarkLand"));
        }

        /// <summary>
        /// А вот тут можно приблизительно показать, как у нас будет работать реальный код
        /// </summary>
        [Fact]
        public void PlaygroundMethod3()
        {
            #region подготовили сервис

            using var context = new ApplicationContext(_optionsBuilder.Options);
            var userRepository = new UserRepository(context);
            var userService = new UserService(userRepository);

            #endregion

            // Подгтовили сервис, которому дали репозиторий, который юзает контекст
            var res = userService.GetUserByLogin("DarkLand");

            Assert.NotNull(res.Value);
        }
    }
}
