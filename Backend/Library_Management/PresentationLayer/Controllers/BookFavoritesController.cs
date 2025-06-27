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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFavoritesByUser(string userId)
        {
            var result = await _service.GetFavoritesByUserAsync(userId);
            return Ok(result);
        }
    }
}
