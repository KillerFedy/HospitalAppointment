using Domain.Entities;
using Domain.Services;
using Hospital.View;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet("userlogin")]
        public ActionResult<UserSearchView> GetUserByLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                return Problem(statusCode: 404, detail: "Не указан логин");
            }

            var userRes = _service.GetUserByLogin(login);
            if(userRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: userRes.Error);
            }

            return Ok(new UserSearchView
            {
                UserId = userRes.Value.UserId,
                Login = userRes.Value.Login,
                Password = userRes.Value.Password,
                PhoneNumber= userRes.Value.PhoneNumber,
                Initials= userRes.Value.Initials,
                Role= userRes.Value.Role
            });
        }

        [HttpPost("createuser")]
        public ActionResult<UserSearchView> CreateUser(UserSearchView userView)
        {
            if (string.IsNullOrEmpty(userView.Login))
                return Problem(statusCode: 404, detail: "Не указан логин");
            if (string.IsNullOrEmpty(userView.Password))
                return Problem(statusCode: 404, detail: "Не указан пароль");

            User user = new User(userView.UserId, userView.Login, userView.Password, userView.PhoneNumber, userView.Initials, userView.Role);
            var userRes = _service.CreateUser(user);
            if (userRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: userRes.Error);
            }

            return Ok(userView);
        }

        [HttpGet("checkuser")]
        public ActionResult CheckUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
                return Problem(statusCode: 404, detail: "Не указан логин");
            if (string.IsNullOrEmpty(password))
                return Problem(statusCode: 404, detail: "Не указан пароль");

            var userRes = _service.CheckUser(login, password);
            if (userRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: userRes.Error);
            }

            return Ok();
        }
    }
}
