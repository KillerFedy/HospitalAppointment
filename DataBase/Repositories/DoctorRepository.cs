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

        public List<Doctor> FindDoctors(int specializationId)
        {
            var doctors =_context.Doctors.Where(doc => doc.SpecializationModelId == specializationId);
            return (List<Doctor>)doctors;
        }

        public List<Doctor> GetAllDoctors()
        {
            var listModels = _context.Doctors.ToList();
            List<Doctor> list = new List<Doctor>();
            foreach (var item in listModels)
            {
                list.Add(item.ToDomain());
            }
            return list;
        }
    }
}
