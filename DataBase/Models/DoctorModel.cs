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
        public SpecializationModel SpecializationModel { get; private set; }
    }
}
