using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reception
    {
        public DateOnly Date { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int UserId { get; private set; }
        public int DoctorId { get; private set; }

        public Reception(DateTime start, DateTime end, int userid, int doctorid)
        {
            StartTime = start;
            EndTime = end;
            UserId = userid;
            DoctorId = doctorid;
        }
    }
}
