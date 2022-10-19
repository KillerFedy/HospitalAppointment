using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using Moq;
using Xunit;

namespace UnitTests
{
    public class ScheduleUnitTests
    {
        private readonly ScheduleService _scheduleService;
        private readonly Mock<IScheduleRepository> _scheduleServiceMock;

        public ScheduleUnitTests()
        {
            _scheduleServiceMock = new Mock<IScheduleRepository>();
            _scheduleService = new ScheduleService(_scheduleServiceMock.Object);
        }

        [Fact]
        public void GetDoctorScheduleByDate_ShouldFail()
        {
            Doctor doctor = new Doctor(default, " ", default);
            DateOnly date = new DateOnly(1, 1, 1);

            _scheduleServiceMock.Setup(repository => repository.GetDoctorScheduleByDate(doctor, date))
                .Returns(() => null);

            var res = _scheduleService.GetDoctorScheduleByDate(doctor, date);

            Assert.True(res.IsFailure);
            Assert.Equal("Schedule not found", res.Error);
        }

        [Fact]
        public void GetDoctorScheduleByDate_ShouldOk()
        {
            Doctor doctor = new Doctor(default, " ", default);
            DateOnly date = new DateOnly(1, 1, 1);

            _scheduleServiceMock.Setup(repository => repository.GetDoctorScheduleByDate(doctor, date))
                .Returns(() => new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1)));

            var res = _scheduleService.GetDoctorScheduleByDate(doctor, date);

            Assert.True(res.Success);
            Assert.Equal(string.Empty, res.Error);
        }

        [Fact]
        public void AddSchedule_ShouldFail()
        {
            Schedule schedule = new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1));

            _scheduleServiceMock.Setup(repository => repository.AddSchedule(schedule))
                .Returns(() => null);

            var res = _scheduleService.AddSchedule(schedule);

            Assert.True(res.IsFailure);
            Assert.Equal("Can not add schedule", res.Error);
        }

        [Fact]
        public void AddSchedule_ShouldOk()
        {
            Schedule schedule = new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1));

            _scheduleServiceMock.Setup(repository => repository.AddSchedule(schedule))
                .Returns(() => new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1)));

            var res = _scheduleService.AddSchedule(schedule);

            Assert.True(res.Success);
            Assert.Equal(string.Empty, res.Error);
        }

        [Fact]
        public void EditSchedule_ShouldFail()
        {
            Schedule schedule = new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1));

            _scheduleServiceMock.Setup(repository => repository.EditSchedule(schedule))
                .Returns(() => null);

            var res = _scheduleService.EditSchedule(schedule);

            Assert.True(res.IsFailure);
            Assert.Equal("Can not edit schedule", res.Error);
        }

        [Fact]
        public void EditSchedule_ShouldOk()
        {
            Schedule schedule = new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1));

            _scheduleServiceMock.Setup(repository => repository.EditSchedule(schedule))
                .Returns(() => new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1)));

            var res = _scheduleService.EditSchedule(schedule);

            Assert.True(res.Success);
            Assert.Equal(string.Empty, res.Error);
        }
    }
}
