using Domain.Services;
using Domain.Interfaces;
using Moq;
using Xunit;


namespace UnitTests
{
    public class UserTests
    {
        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserTests()
        {
            // ���������� ���������� Moq, ����� �������������� �������� ������
            // �� ������ ���������� ����������, �� ������� ��� �������, ��� ���, ��� �����, ��� ��������������� ����������
            // ����� ������� �� ����������� ������ ������ ��� �������� ���������, ������� �������, "������" (mock) ����������� 
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public void LoginIsEmptyOrNull_ShouldFail()
        {
            var res = _userService.GetUserByLogin(string.Empty);

            Assert.True(res.IsFailure); // �������, ��� ������ ������
            Assert.Equal("����� �� ��� ������", res.Error); // ����������, ��� ������ ������ ��
        }

        [Fact]
        public void UserNotFound_ShouldFail()
        {
            // It.IsAny ��������, ��� �� �������������� ��, ��� ������ ������� ����� ��� ����������� �� ����, ����� ����� �� �������
            // �� ���� � ������ ������, ����� �������� ����� string, ��� ��� �� ��������� �������� ��������, ��� � ����� ������ ���� ������� ����
            _userRepositoryMock.Setup(repository => repository.GetByLogin(It.IsAny<string>()))
                .Returns(() => null);

            var res = _userService.GetUserByLogin("qwertyuiop"); // ��� ������ � ���� ������

            Assert.True(res.IsFailure); // �������, ��� ������ ������
            Assert.Equal("������������ �� ������", res.Error); // ����������, ��� ������ ������ ��
        }


    }
}