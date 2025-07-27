using BussinessLayer.DTOs.User;
using BussinessLayer.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users/students
        [HttpGet("students")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetStudents()
        {
            var students = await _userService.GetStudentsAsync();
            return Ok(students);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            var result = await _userService.CreateUserAsync(dto);
            return result == null ? Conflict("Student already exists.") : CreatedAtAction(nameof(GetStudents), new { }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var result = await _userService.UpdateUserAsync(dto);
            return result ? NoContent() : NotFound();
        }
        [HttpPut("{id}/ban")]
        public async Task<IActionResult> BanUser(string id)
        {
            var result = await _userService.ToggleBanStatusAsync(id, true);
            return result ? NoContent() : NotFound();
        }

        [HttpPut("{id}/unban")]
        public async Task<IActionResult> UnbanUser(string id)
        {
            var result = await _userService.ToggleBanStatusAsync(id, false);
            return result ? NoContent() : NotFound();
        }
    }
}
