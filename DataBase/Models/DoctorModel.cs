using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class DoctorModel
    {
        public int DoctorId { get; private set; }
        public string Initials { get; private set; }
        public int SpecializationModelId { get; private set; }

        public DoctorModel(int id, string init, int spec)
        {
            DoctorId = id;
            Initials = init;
            SpecializationModelId = spec;
        }
    }
}
