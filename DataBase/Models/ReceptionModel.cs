using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class ReceptionModel
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int UserId { get; private set; }
        public int DoctorId { get; private set; }
    }
}
