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
    public class ReceptionUnitTests
    {
        private readonly ReceptionService _receptionService;
        private readonly Mock<IReceptionRepository> _receptionRepositoryMock;

        public ReceptionUnitTests()
        {
            _receptionRepositoryMock = new Mock<IReceptionRepository>();
            _receptionService = new ReceptionService(_receptionRepositoryMock.Object);
        }

        [Fact]
        public void SaveAppointmentToAnyDoctor_ShouldFail()
        {
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            _receptionRepositoryMock.Setup(repository => repository.SaveAppointment(start, end))
                        .Returns(() => null);

            var res = _receptionService.SaveAppointment(start, end);

            Assert.True(res.IsFailure);
            Assert.Equal("Can not save appointment", res.Error);
        }

        [Fact]
        public void SaveAppointmentToAnyDoctor_ShouldOk()
        {
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            _receptionRepositoryMock.Setup(repository => repository.SaveAppointment(start, end))
                        .Returns(() => new Reception(new DateTime(1, 1, 1), new DateTime(1, 1, 1), default, default));

            var res = _receptionService.SaveAppointment(start, end);

            Assert.True(res.Success);
            Assert.Equal(string.Empty, res.Error);
        }

        public void SaveAppointmentToSpecificDoctor_ShouldFail()
        {
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            Doctor doctor = new Doctor(default, "", default);
            _receptionRepositoryMock.Setup(repository => repository.SaveAppointment(start, end, doctor))
                        .Returns(() => null);

            var res = _receptionService.SaveAppointment(start, end, doctor);

            Assert.True(res.IsFailure);
            Assert.Equal("Can not save appointment", res.Error);
        }

        [Fact]
        public void SaveAppointmentToSpecificDoctor_ShouldOk()
        {
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            Doctor doctor = new Doctor(default, "", default);
            _receptionRepositoryMock.Setup(repository => repository.SaveAppointment(start, end, doctor))
                        .Returns(() => new Reception(new DateTime(1, 1, 1), new DateTime(1, 1, 1), default, default));

            var res = _receptionService.SaveAppointment(start, end, doctor);

            Assert.True(res.Success);
            Assert.Equal(string.Empty, res.Error);
        }

        [Fact]
        public void GetFreeAppointmentDateList_ShouldFail()
        {
            Specialization specialization = new Specialization(default, " ");
            _receptionRepositoryMock.Setup(repository => repository.GetFreeAppointmentDateList(specialization))
                        .Returns(() => null);

            var res = _receptionService.GetFreeAppointmentDateList(specialization);

            Assert.True(res.IsFailure);
            Assert.Equal("Can not get date list", res.Error);
        }

        [Fact]
        public void GetFreeAppointmentDateList_ShouldOk()
        {
            Specialization specialization = new Specialization(default, " ");
            _receptionRepositoryMock.Setup(repository => repository.GetFreeAppointmentDateList(specialization))
                        .Returns(() => new List<DateTime>());

            var res = _receptionService.GetFreeAppointmentDateList(specialization);

            Assert.True(res.Success);
            Assert.Equal(string.Empty, res.Error);
        }
    }
}
