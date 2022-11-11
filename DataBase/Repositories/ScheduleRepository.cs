using DataBase.Converters;
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
            _context.AddAsync(schedule);
            _context.SaveChanges();
            return schedule;
        }

        public Schedule EditSchedule(Schedule schedule)
        {
            _context.Remove(schedule);
            _context.SaveChanges();
            return schedule;
        }

        public Schedule GetDoctorScheduleByDate(Doctor doctor, DateTime date)
        {
            var schedule = _context.Schedules.FirstOrDefault(s => (s.DoctorId == doctor.DoctorId || s.StartWorkTime == date));
            return schedule.ToDomain();
        }
    }
}
