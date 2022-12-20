using Domain.Entities;
using Domain.Services;
using Hospital.View;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("reception")]
    public class ReceptionController : ControllerBase
    {
        private readonly ReceptionService _service;
        public ReceptionController(ReceptionService service)
        {
            _service = service;
        }

        [HttpPost("saveappointment")]
        public ActionResult<ReceptionSearchView> SaveAppointment(DateTime start, DateTime end)
        {
            var res = _service.SaveAppointment(start, end);
            if(res.IsFailure)
            {
                return Problem(statusCode: 404, detail: "Не удалось сохранить");
            }
            ReceptionSearchView view = new ReceptionSearchView()
            {
                StartTime = start,
                EndTime = end,
                DoctorId = res.Value.DoctorId,
                UserId = res.Value.UserId
            };
            return Ok(view);
        }

        [HttpPost("saveappointmentdoctor")]
        public ActionResult<ReceptionSearchView> SaveAppointment(DateTime start, DateTime end, DoctorSearchView docView)
        {
            Doctor doctor = new Doctor(docView.DoctorId, docView.Initials, docView.SpecializationId);
            var res = _service.SaveAppointment(start, end, doctor);
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: "Не удалось сохранить");
            }
            ReceptionSearchView view = new ReceptionSearchView()
            {
                StartTime = start,
                EndTime = end,
                DoctorId = res.Value.DoctorId,
                UserId = res.Value.UserId
            };
            return Ok(view);
        }

        [HttpGet("freeappointmentlist")]
        public ActionResult<List<DateTime>> GetFreeAppointmentDateList(int specializationId)
        {
            var res = _service.GetFreeAppointmentDateList(specializationId);
            if(res.Value.Count == 0)
            {
                return Problem(statusCode:404, detail:"Не удалось получить");
            }
            return Ok(res.Value);
        }
    }
}
