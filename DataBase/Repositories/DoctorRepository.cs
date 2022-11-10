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
            _context.AddAsync(doctor);
            _context.SaveChangesAsync();
            return doctor;
        }

        public bool DeleteDoctor(int doctorid)
        {
            var doctor = _context.Doctors.FirstOrDefault(doc => doc.DoctorId == doctorid);
            _context.Remove(doctor);
            return true;
        }

        public Doctor FindDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> FindDoctor(Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return (IEnumerable<Doctor>)_context.Doctors.ToList();
        }
    }
}
