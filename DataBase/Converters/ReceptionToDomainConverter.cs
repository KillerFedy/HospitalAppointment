using DataBase.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Converters
{
    public static class ReceptionToDomainConverter
    {
        public static Reception? ToDomain(this ReceptionModel model)
        {
            return new Reception(model.StartTime, model.EndTime, model.UserId, model.DoctorId);
        }
    }
}
