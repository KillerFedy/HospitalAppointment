using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Interfaces
{
    public interface IDoctorRepository
    {
        public Doctor CreateDoctor(Doctor doctor);

        public bool DeleteDoctor(int doctorid);

        public IEnumerable<Doctor> GetAllDoctors();

        public Doctor FindDoctor(int id);

        public IEnumerable<Doctor> FindDoctors(int specializationId);
    }
}
