using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class ReceptionRepository : IReceptionRepository
    {
        private readonly ApplicationContext _context;

        public ReceptionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<DateTime> GetFreeAppointmentDateList(Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public bool IsReserveReception(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public Reception SaveAppointment(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public Reception SaveAppointment(DateTime startTime, DateTime endTime, Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
