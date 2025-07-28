using BussinessLayer.DTOs.BookFavorite;
using BussinessLayer.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookFavoritesController : ControllerBase
    {
        private readonly IBookFavoriteService _service;

        public BookFavoritesController(IBookFavoriteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites([FromBody] BookFavoriteCreateDto dto)
        {
            try
            {
                // IMPORTANT: Get UserId from the authenticated user's claims
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    // This scenario should ideally not happen if [Authorize] is working,
                    // but it's good for defensive programming.
                    return Unauthorized(new { message = "User not authenticated or UserId claim missing." });
                }

                // Call the service with BookId from DTO and UserId from claims
                var result = await _service.AddFavoriteAsync(dto.BookId, userId);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                // _logger.LogError(ex, "Error adding book to favorites.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while adding to favorites." });
            }
        }

        [HttpGet("student/{studentCode}")]
        public async Task<IActionResult> GetFavoritesByStudentCode(string studentCode)
        {
            var result = await _service.GetFavoritesByStudentCodeAsync(studentCode);
            return Ok(result);
        }
        [HttpDelete("{bookId}/student/{studentCode}")]
        public async Task<IActionResult> RemoveFavorite(string bookId, string studentCode)
        {
            var success = await _service.RemoveFavoriteByStudentCodeAsync(bookId, studentCode);

            if (!success)
            {
                return NotFound(new { message = "Favorite not found." });
            }

            return NoContent(); // 204: Xoá thành công, không trả về dữ liệu
        }
    }
}
