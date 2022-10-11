using Domain.Services;
using Domain.Interfaces;
using Moq;
using Xunit;
using Domain.Entities;

namespace UnitTests;


public class UserTests
{
    private readonly UserService _userService;
    private readonly Mock<IUserRepository> _userRepository;
    public UserTests()
    {
        _userRepository = new Mock<IUserRepository>();
        _userService = new UserService(_userRepository.Object);
    }

    [Fact]
    public void GetUserByLoginEmptyLogin_ShouldFail()
    {
        var res = _userService.GetUserByLogin(string.Empty);

        Assert.True(res.IsFailure);
        Assert.Equal("Empty login", res.Error);
    }


    [Fact]
    public void GetUserByLoginUserNotFound_ShouldFail()
    {
        _userRepository.Setup(repository => repository.GetByLogin(It.IsAny<string>()))
                    .Returns(() => null);

        var res = _userService.GetUserByLogin("qwertyuiop");

        Assert.True(res.IsFailure);
        Assert.Equal("User not found", res.Error);
    }

    [Fact]
    public void GetUserByLoginUserFound_ShouldOk()
    {
        string login = "Amongus";
        _userRepository.Setup(repository => repository.GetByLogin(It.IsAny<string>()))
                    .Returns(() => new User(default, login, "", "", "", default));

        var res = _userService.GetUserByLogin(login);

        Assert.True(res.Success);
        Assert.Equal(login, res.Value.Login);
    }

    [Fact]
    public void CheckUserEmptyPassword_ShouldFail()
    {
        var res = _userService.CheckUser("Aboba", string.Empty);

        Assert.True(res.IsFailure);

        Assert.Equal("Empty password", res.Error);
    }

    [Fact]
    public void CheckUser_ShouldOk()
    {
        _userRepository.Setup(repository => repository.GetByLogin(It.IsAny<string>()))
                    .Returns(() => new User(default, "Aboba", "1", "", "", default));

        var res = _userService.CheckUser("Aboba", "1");

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }

    [Fact]
    public void CreateUserNoData_ShouldFail()
    {
        var res = _userService.CreateUser(new User(default, "", "", "", "", default));

        Assert.True(res.IsFailure);
        Assert.Equal("Empty login", res.Error);
    }

    [Fact]
    public void CreateUserEmptyPassword_ShouldFail()
    {
        var res = _userService.CreateUser(new User(default, "Amongus", "", "", "", default));

        Assert.True(res.IsFailure);
        Assert.Equal("Empty password", res.Error);
    }

    [Fact]
    public void CreateUser_ShouldOk()
    {
        string login = "Amongus";

        _userRepository.Setup(repository => repository.GetByLogin(It.IsAny<string>()))
                    .Returns(() => null);

        var res = _userService.CreateUser(new User(default, "AnotherLogin", "aboba", "88005553535", "Sharp", default));

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }
}