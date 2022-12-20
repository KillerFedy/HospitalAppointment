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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationContext _context;

        public DoctorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Doctor CreateDoctor(Doctor doctor)
        {
            DoctorModel model = new DoctorModel
            {
                Id = doctor.DoctorId,
                Initials = doctor.Initials,
                SpecializationModelId = doctor.SpecializationId
            };
            
            _context.Doctors.Add(model);
            _context.SaveChanges();
            return doctor;
        }

        public bool DeleteDoctor(int doctorid)
        {
            var doctor = _context.Doctors.FirstOrDefault(doc => doc.Id == doctorid);
            _context.Remove(doctor);
            _context.SaveChanges();
            return true;
        }

        public Doctor FindDoctor(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(doc => doc.Id == id);
            return doctor?.ToDomain();
        }

        public IEnumerable<Doctor> FindDoctors(int specializationId)
        {
            var doctors =_context.Doctors.Where(doc => doc.SpecializationModelId == specializationId);
            return (IEnumerable<Doctor>)doctors;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return (IEnumerable<Doctor>)_context.Doctors;
        }
    }
}
