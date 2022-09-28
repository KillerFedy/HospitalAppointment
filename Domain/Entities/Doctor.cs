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
        public Specialization Specialization { get; private set; }
    }
}
