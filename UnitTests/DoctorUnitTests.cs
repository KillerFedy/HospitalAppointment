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
    public class DoctorUnitTests
    {
        private readonly DoctorService _doctorService;
        private readonly Mock<IDoctorRepository> _doctorRepositoryMock;

        public DoctorUnitTests()
        {
            _doctorRepositoryMock = new Mock<IDoctorRepository>();
            _doctorService = new DoctorService(_doctorRepositoryMock.Object);
        }

        [Fact]
        public void GetDoctorNotByIdFound_ShouldFail()
        {
            _doctorRepositoryMock.Setup(repository => repository.FindDoctor(It.IsAny<int>()))
                .Returns(() => null);

            var res = _doctorService.GetDoctor(1);

            Assert.True(res.IsFailure);
            Assert.Equal("Doctor not found", res.Error);
        }

        [Fact]
        public void GetDoctorById_ShouldOk()
        {
            int id = 1;
            _doctorRepositoryMock.Setup(repository => repository.FindDoctor(It.IsAny<int>()))
                .Returns(() => new Doctor(id, "", default));

            var res = _doctorService.GetDoctor(id);

            Assert.True(res.Success);
            Assert.Equal(id, res.Value.DoctorId);
        }

        [Fact]
        public void GetDoctorsBySpec_ShouldFail()
        {
            _doctorRepositoryMock.Setup(repository => repository.FindDoctor(It.IsAny<Specialization>()))
                .Returns(() => null);

            var res = _doctorService.FindDoctor(new Specialization(default, "Name"));

            Assert.True(res.IsFailure);
            Assert.Equal("Can not get list of doctors", res.Error);
        }

        [Fact]
        public void GetDoctorsBySpecNullSpec_ShouldFail()
        {
            var res = _doctorService.FindDoctor(new Specialization(default, ""));

            Assert.True(res.IsFailure);
            Assert.Equal("Empty specialization", res.Error);
        }

        [Fact]
        public void GetDoctorsBySpec_ShouldOk()
        {
            _doctorRepositoryMock.Setup(repository => repository.FindDoctor(It.IsAny<Specialization>()))
                .Returns(() => new List<Doctor>());

            var res = _doctorService.FindDoctor(new Specialization(default, "Amongus"));

            Assert.True(res.Success);
            Assert.Equal(string.Empty, res.Error);
        }

        [Fact]
        public void GetDoctorList_ShouldFail()
        {
            _doctorRepositoryMock.Setup(repository => repository.GetAllDoctors())
                .Returns(() => null);

            var res = _doctorService.GetAllDoctors();

            Assert.True(res.IsFailure);
            Assert.Equal("Can not get list of doctors", res.Error);
        }

        [Fact]
        public void GetDoctorList_ShouldOk()
        {
            _doctorRepositoryMock.Setup(repository => repository.GetAllDoctors())
                .Returns(() => new List<Doctor>());

            var res = _doctorService.GetAllDoctors();

            Assert.True(res.Success);
            Assert.Equal(string.Empty, res.Error);
        }

        [Fact]
        public void DeleteDoctorEntityNotFound_ShouldFail()
        {
            _doctorRepositoryMock.Setup(repository => repository.FindDoctor(It.IsAny<int>()))
                .Returns(() => null);

            var res = _doctorService.DeleteDoctor(1);

            Assert.True(res.IsFailure);
            Assert.Equal("Doctor not found", res.Error);
        }

        [Fact]
        public void DeleteDoctorNotDelete_ShouldFail()
        {
            int id = 1;
            _doctorRepositoryMock.Setup(repository => repository.FindDoctor(id))
                .Returns(() => new Doctor(id, "Amongus", default));

            _doctorRepositoryMock.Setup(repository => repository.DeleteDoctor(It.IsAny<int>()))
                .Returns(() => false);

            var res = _doctorService.DeleteDoctor(id);

            Assert.True(res.IsFailure);
            Assert.Equal("Doctor not deleted", res.Error);
        }

        [Fact]
        public void DeleteDoctor_ShouldOk()
        {
            int id = 1;
            _doctorRepositoryMock.Setup(repository => repository.FindDoctor(id))
                .Returns(() => new Doctor(id, "Amongus", default));
            _doctorRepositoryMock.Setup(repository => repository.DeleteDoctor(It.IsAny<int>()))
                .Returns(() => true);

            var res = _doctorService.DeleteDoctor(id);

            Assert.True(res.Success);
            Assert.Equal(string.Empty, res.Error);
        }

        [Fact]
        public void CreateDoctorEmptyName_ShouldFail()
        {
            var res = _doctorService.CreateDoctor(new Doctor(default, "", default));

            Assert.True(res.IsFailure);
            Assert.Equal("Empty doctor name", res.Error);
        }

        [Fact]
        public void CreateDoctorNullSpecialization_ShouldFail()
        {
            var res = _doctorService.CreateDoctor(new Doctor(default, "Amongus", default));

            Assert.True(res.IsFailure);
            Assert.Equal("No specialization", res.Error);
        }

        [Fact]
        public void CreateDoctor_ShouldOk()
        {
            var res = _doctorService.CreateDoctor(
                new Doctor(default, "Amongus", new Specialization(10, "Spec")));

            Assert.True(res.Success);
            Assert.Equal(string.Empty, res.Error);
        }
    }
}
