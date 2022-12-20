using Domain.Entities;
using Domain.Services;
using Hospital.View;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("schedule")]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _service;
        public ScheduleController(ScheduleService service)
        {
            _service = service;
        }

        [HttpGet("getschedule")]
        public ActionResult<ScheduleSearchView> GetDoctorScheduleByDate(DoctorSearchView model, DateTime date) 
        {
            Doctor doc = new Doctor(model.DoctorId, model.Initials, model.SpecializationId);
            var res = _service.GetDoctorScheduleByDate(doc, date);
            if(res.IsFailure)
            {
                return Problem(statusCode: 404, detail: "Не найден");
            }
            ScheduleSearchView view= new ScheduleSearchView { 
                DoctorId = res.Value.DoctorId,
                StartWorkTime = res.Value.StartWorkTime,
                EndWorkTime = res.Value.EndWorkTime
            };
            return Ok(view);
        }

        [HttpGet("addschedule")]
        public ActionResult<ScheduleSearchView> AddSchedule(ScheduleSearchView model)
        {
            Schedule schedule = new Schedule(model.DoctorId, model.StartWorkTime, model.EndWorkTime);
            var res = _service.AddSchedule(schedule);
            if(res.IsFailure)
            {
                return Problem(statusCode: 404, detail: "Невозможно добавить");
            }
            return Ok(model);
        }

        [HttpGet("editschedule")]
        public ActionResult<ScheduleSearchView> EditSchedule(ScheduleSearchView model)
        {
            Schedule schedule = new Schedule(model.DoctorId, model.StartWorkTime, model.EndWorkTime);
            var res = _service.EditSchedule(schedule);
            if(res.IsFailure)
            {
                return Problem(statusCode: 404, detail: "Невозможно изменить");
            }
            return Ok(model);
        }
    }
}
