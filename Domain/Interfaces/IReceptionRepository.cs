using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReceptionRepository
    {

        public Reception SaveAppointment(DateTime startTime, DateTime endTime);
        public Reception SaveAppointment(DateTime startTime, DateTime endTime, Doctor doctor);
        public List<DateOnly> GetFreeAppointmentDateList(Specialization specialization);
        public bool IsReserveReception(DateTime startTime, DateTime endTime);
    }
}
