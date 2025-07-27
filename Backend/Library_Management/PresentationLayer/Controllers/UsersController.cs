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

        // GET: api/Users/students
        [HttpGet("students")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetStudents()
        {
            var students = await _userService.GetStudentsAsync();
            return Ok(students);
        }

        [Authorize(Roles = "2")] // Yêu cầu người dùng phải đăng nhập
        [HttpPut("profile")]
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
    }
}
