using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services
{
    public class ReceptionService
    {
        private readonly IReceptionRepository _receptionRepository;

        public ReceptionService(IReceptionRepository receptionRepository)
        {
            _receptionRepository = receptionRepository;
        }

        public Result<Reception> SaveAppointment(DateTime start, DateTime end)
        {
            Reception reception = _receptionRepository.SaveAppointment(start, end);

            return (reception is null && _receptionRepository.IsReserveReception(start, end)) ? Result.Fail<Reception>("Can not save appointment") : Result.Ok(reception);

        }
        public Result<Reception> SaveAppointment(DateTime start, DateTime end, Doctor doctor)
        {
            Reception reception = _receptionRepository.SaveAppointment(start, end, doctor);

            return (reception is null && _receptionRepository.IsReserveReception(start, end)) ? Result.Fail<Reception>("Can not save appointment") : Result.Ok(reception);

        }
        public Result<List<DateTime>> GetFreeAppointmentDateList(int specializationId)
        {
            List<DateTime> dates = _receptionRepository.GetFreeAppointmentDateList(specializationId);

            return dates is null ? Result.Fail<List<DateTime>>("Can not get date list") : Result.Ok(dates);
        }
    }
}
