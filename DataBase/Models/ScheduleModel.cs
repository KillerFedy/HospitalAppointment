using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class ScheduleModel
    {
        public int DoctorId { get; private set; }
        public DateTime StartWorkTime { get; private set; }
        public DateTime EndWorkTime { get; private set; }

        public ScheduleModel(int id, DateTime startWorkTime, DateTime endWorkTime)
        {
            DoctorId = id;
            StartWorkTime = startWorkTime;
            EndWorkTime = endWorkTime;
        }
    }
}
