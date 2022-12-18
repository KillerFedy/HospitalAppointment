using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorAdaptor)
        {
            _doctorRepository = doctorAdaptor;
        }

        public Result<Doctor> FindDoctor(int doctorId)
        {
            Doctor? doctor = _doctorRepository.FindDoctor(doctorId);

            return doctor is null ? Result.Fail<Doctor>("Doctor not found") : Result.Ok(doctor);
        }
        public Result<List<Doctor>> GetAllDoctors()
        {
            List<Doctor>? doctors = (List<Doctor>)_doctorRepository.GetAllDoctors();

            return doctors is null ? Result.Fail<List<Doctor>>("Can not get list of doctors") : Result.Ok(doctors);
        }
        public Result<bool> DeleteDoctor(int doctorId)
        {
            var doctor = _doctorRepository.FindDoctor(doctorId);

            if (doctor is null)
                return Result.Fail<bool>("Doctor not found");

            bool result = _doctorRepository.DeleteDoctor(doctorId);

            return result ? Result.Ok(result) : Result.Fail<bool>("Doctor not deleted");
        }
        public Result<Doctor> CreateDoctor(Doctor doctor)
        {
            if (string.IsNullOrEmpty(doctor.Initials))
                return Result.Fail<Doctor>("Empty doctor name");
            if (doctor.SpecializationId == -1)
                return Result.Fail<Doctor>("No specialization");

            return Result.Ok(doctor);
        }
    }
}
