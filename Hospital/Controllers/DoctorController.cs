using Domain.Entities;
using Domain.Services;
using Hospital.View;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DoctorService _service;
        public DoctorController(DoctorService service)
        {
            _service = service;
        }

        public ActionResult<DoctorSearchView> FindDoctor(int id)
        {
            var doctor = _service.FindDoctor(id);
            if(doctor.IsFailure)
            {
                return Problem(statusCode: 404, detail: "Доктор не найден");
            }
            DoctorSearchView doc = new DoctorSearchView
            {
                DoctorId= id,
                Initials = doctor.Value.Initials,
                SpecializationId = doctor.Value.SpecializationId
            };
            return View(doc);
        }

        public ActionResult<List<DoctorSearchView>> GetAllDoctors()
        {
            var list = _service.GetAllDoctors();
            List<DoctorSearchView> doctorSearchViews= new List<DoctorSearchView>();
            foreach (var doctor in list.Value)
            {
                var view = new DoctorSearchView
                {
                    DoctorId = doctor.DoctorId,
                    Initials = doctor.Initials,
                    SpecializationId = doctor.SpecializationId
                };
                doctorSearchViews.Add(view);
            }
            if(doctorSearchViews.Count == 0) {
                return Problem(statusCode: 404, detail:"Невозможно получить список");
            }
            return Ok(doctorSearchViews);
        }

        public ActionResult<bool> DeleteDoctor(int id)
        {
            var doctor = _service.FindDoctor(id);
            if(doctor.IsFailure)
            {
                return Problem(statusCode: 404, detail: "Не удалось удалить доктора");
            }
            var res = _service.DeleteDoctor(id);
            return Ok(res.Value);
        }

        public ActionResult<DoctorSearchView> CreateDoctor(DoctorSearchView doctorSearchView)
        {
            if(doctorSearchView.Initials == string.Empty)
            {
                return Problem(statusCode:404, detail:"Имя доктора некорректное");
            }
            if(doctorSearchView.SpecializationId == -1)
            {
                return Problem(statusCode: 404, detail: "Отсутсвует специализация");
            }
            Doctor doctor = new Doctor(doctorSearchView.DoctorId, doctorSearchView.Initials, doctorSearchView.SpecializationId);
            _service.CreateDoctor(doctor);
            return Ok(doctorSearchView);
        }
    }
}
