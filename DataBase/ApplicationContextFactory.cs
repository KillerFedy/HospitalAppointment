using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder =  new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=yuy;Username=KillerFedy;Password=281103@QWas");
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
