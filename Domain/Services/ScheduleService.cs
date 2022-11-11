using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Entities;

namespace Domain.Services
{
    public class ScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Result<Schedule> GetDoctorScheduleByDate(Doctor doctor, DateTime date)
        {
            Schedule schedule = _scheduleRepository.GetDoctorScheduleByDate(doctor, date);

            return schedule is null ? Result.Fail<Schedule>("Schedule not found") : Result.Ok(schedule);
        }

        public Result<Schedule> AddSchedule(Schedule schedule)
        {
            Schedule result = _scheduleRepository.AddSchedule(schedule);

            return result is null ? Result.Fail<Schedule>("Can not add schedule") : Result.Ok(schedule);
        }

        public Result<Schedule> EditSchedule(Schedule schedule)
        {
            Schedule result = _scheduleRepository.EditSchedule(schedule);

            return result is null ? Result.Fail<Schedule>("Can not edit schedule") : Result.Ok(result);
        }
    }
}
