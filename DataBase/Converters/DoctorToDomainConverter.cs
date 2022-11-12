using DataBase.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Converters
{
    public static class DoctorToDomainConverter
    {
        public static Doctor? ToDomain(this DoctorModel model)
        {
            return new Doctor(model.Id, model.Initials, model.SpecializationModelId);
        }
    }
}
