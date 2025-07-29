using BussinessLayer.DTOs.User;
using BussinessLayer.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet("student/{studentCode}")]
        [Authorize(Roles = "0,1,2")]
        public async Task<IActionResult> GetUserByStudentCode(string studentCode)
        {
            var user = await _userService.GetUserByStudentCodeAsync(studentCode);
            if (user == null) return NotFound();

            var userDto = new
            {
                user.Id,
                user.Username,
                user.StudentCode,
                user.Email,
                user.PhoneNumber
                // KHÔNG trả Role hay các collection
            };

            return Ok(userDto);
        }
        // GET: api/Users/students
        [HttpGet("students")]
        [Authorize(Roles = "0,1,2")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetStudents()
        {
            var students = await _userService.GetStudentsAsync();
            return Ok(students);
        }

        [HttpGet("profile")]
        [Authorize(Roles = "0,1,2")] // Có thể điều chỉnh vai trò được phép truy cập profile
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> GetProfile()
        {
            // Lấy UserId từ token JWT
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var userDto = await _userService.GetUserByIdAsync(userId);
            if (userDto == null)
            {
                return NotFound("User profile not found.");
            }

            return Ok(userDto);
        }

        [Authorize] // Yêu cầu người dùng phải đăng nhập
        [HttpPut("profile")]
        [Authorize(Roles = "0,1,2")]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateProfileDto updateDto)
        {
            // Lấy UserId từ token JWT
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var updatedUser = await _userService.UpdateProfileAsync(userId, updateDto);

            if (updatedUser == null)
            {
                return NotFound("User not found.");
            }

            return Ok(updatedUser);
        }

        [HttpPost]
        [Authorize(Roles = "0,1")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            var result = await _userService.CreateUserAsync(dto);
            return result == null ? Conflict("Student already exists.") : CreatedAtAction(nameof(GetStudents), new { }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "0,1")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var result = await _userService.UpdateUserAsync(dto);
            return result ? NoContent() : NotFound();
        }

        [HttpPut("{id}/ban")]
        [Authorize(Roles = "0,1")]
        public async Task<IActionResult> BanUser(string id)
        {
            var result = await _userService.ToggleBanStatusAsync(id, true);
            return result ? NoContent() : NotFound();
        }

        [HttpPut("{id}/unban")]
        [Authorize(Roles = "0,1")]
        public async Task<IActionResult> UnbanUser(string id)
        {
            var result = await _userService.ToggleBanStatusAsync(id, false);
            return result ? NoContent() : NotFound();
        }
    }
}
