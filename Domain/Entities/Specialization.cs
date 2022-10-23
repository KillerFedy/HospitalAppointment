using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Specialization
    {
        public int SpecializationId { get; private set; }
        public string SpecializationName { get; private set; }

        public Specialization(int id, string name)
        {
            SpecializationId = id;
            SpecializationName = name;
        }
    }
}
