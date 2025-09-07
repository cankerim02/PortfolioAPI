using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UsersController(IUserServices userService)
        {
            _userService = userService;
        }

        //[Authorize(Roles = "admin")] // Aktif edebilirsin istersen
        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] UserAddDto userDto)
        {
            var result = await _userService.AddUserAsync(userDto);
            if (!result)
                return BadRequest("Bu e-posta ile zaten bir kullanıcı var.");

            return Ok("Kullanıcı başarıyla eklendi.");
        }
    }
}
