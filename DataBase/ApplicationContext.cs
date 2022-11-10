using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataBase.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext: DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<ScheduleModel> Schedules { get; set; }
        public DbSet<SpecializationModel> Specializations { get; set; }
        public DbSet<ReceptionModel> Receptions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("");
        }
    }
}
