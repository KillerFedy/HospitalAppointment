using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IScheduleRepository
    {
        public Schedule GetDoctorScheduleByDate(Doctor doctor, DateTime date);
        public Schedule AddSchedule(Schedule schedule);
        public Schedule EditSchedule(Schedule schedule);
    }
}
