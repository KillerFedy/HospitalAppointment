using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationContext _context;

        public ScheduleRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Schedule AddSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Schedule EditSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Schedule GetDoctorScheduleByDate(Doctor doctor, DateOnly date)
        {
            throw new NotImplementedException();
        }
    }
}
