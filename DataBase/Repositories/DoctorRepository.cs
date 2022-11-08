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
            throw new NotImplementedException();
        }

        public bool DeleteDoctor(int doctorid)
        {
            throw new NotImplementedException();
        }

        public Doctor FindDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> FindDoctor(Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctors()
        {
            throw new NotImplementedException();
        }
    }
}
