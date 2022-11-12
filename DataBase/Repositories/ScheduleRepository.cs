using DataBase.Converters;
using DataBase.Models;
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
            ScheduleModel model = new ScheduleModel
            {
                Id = schedule.DoctorId,
                StartWorkTime = schedule.StartWorkTime,
                EndWorkTime = schedule.EndWorkTime
            };
            _context.Schedules.Add(model);
            _context.SaveChanges();
            return schedule;
        }

        public Schedule EditSchedule(Schedule schedule)
        {
            ScheduleModel model = new ScheduleModel
            {
                Id = schedule.DoctorId,
                StartWorkTime = schedule.StartWorkTime,
                EndWorkTime = schedule.EndWorkTime
            };
            _context.Remove(model);
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
