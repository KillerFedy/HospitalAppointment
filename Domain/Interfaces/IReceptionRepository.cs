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
        public Reception SaveAppointment(DateTime startTime, DateTime endTime, Doctor doctor, User user);
        public List<DateTime> GetFreeAppointmentDateList(int specializationId);
        public bool IsReserveReception(DateTime startTime, DateTime endTime);
    }
}
