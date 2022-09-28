using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Schedule
    {
        public int DoctorId { get; private set; }
        public DateTime StartWorkTime { get; private set; }
        public DateTime EndWorkTime { get; private set; }
    }
}
