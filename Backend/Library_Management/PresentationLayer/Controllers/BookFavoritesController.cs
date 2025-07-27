using BussinessLayer.DTOs.BookFavorite;
using BussinessLayer.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                var result = await _service.AddFavoriteAsync(dto);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
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
