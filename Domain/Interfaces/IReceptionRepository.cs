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

        public Reception SaveAppointment(DateOnly date);
        public Reception SaveAppointment(DateOnly date, Doctor doctor);
        public List<DateOnly> GetFreeAppointmentDateList(Specialization specialization);
    }
}
