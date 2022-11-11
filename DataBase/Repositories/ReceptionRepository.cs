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
    public class ReceptionRepository : IReceptionRepository
    {
        private readonly ApplicationContext _context;

        public ReceptionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<DateTime> GetFreeAppointmentDateList(int specializationId)
        {
            List<DateTime> dateTimes = new List<DateTime>();
            var doctor = _context.Doctors.FirstOrDefault(doc => doc.SpecializationModelId == specializationId);
            var appointmentForSpecialization = _context.Receptions.ToList();
            for (int i = 0; i < appointmentForSpecialization.Count; ++i)
            {
                if (_context.Receptions.FirstOrDefault(a => doctor.DoctorId == appointmentForSpecialization[i].DoctorId) != null)
                {
                    dateTimes.Add(appointmentForSpecialization[i].StartTime);
                }
            }
            return dateTimes;
        }

        public bool IsReserveReception(DateTime startTime, DateTime endTime)
        {
            var reception = _context.Receptions.FirstOrDefault(res => (res.StartTime == startTime && res.EndTime == endTime));
            if(reception != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Reception SaveAppointment(DateTime startTime, DateTime endTime, Doctor doctor, User user)
        {
            Reception reception = new Reception(startTime, endTime, user.UserId, doctor.DoctorId);
            ReceptionModel model = new ReceptionModel(reception.StartTime, reception.EndTime, reception.UserId, reception.DoctorId);
            _context.Receptions.Add(model);
            return reception;
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
