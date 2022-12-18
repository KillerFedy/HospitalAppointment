using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Doctor
    {
        public int DoctorId { get; private set; }
        public string Initials { get; private set; }
        public int SpecializationId { get; private set; }

        public Doctor(int id, string init, int spec)
        {
            DoctorId = id;
            Initials = init;
            SpecializationId = spec;
        }
    }
}
