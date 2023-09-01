using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("user")]

    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Policy = "admin")]
        public IActionResult GetUsers()
        {
            IEnumerable<UserDto> usersResponse = _repository.GetUsers();

            return Ok(usersResponse);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserDtoInsert user)
        {
            UserDto? userSearch = _repository.GetUserByEmail(user.Email!);

            if (userSearch != null)
            {
                return Conflict(new { message = "User email already exists" });
            }
            return Created("user", _repository.Add(user));
        }
    }
}