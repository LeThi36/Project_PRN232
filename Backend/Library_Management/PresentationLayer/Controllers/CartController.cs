using BussinessLayer.Services;
using BussinessLayer.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet("{studentCode}")]
        public async Task<IActionResult> GetCartItems(string studentCode)
        {
            var result = await _service.GetCartItemsByStudentCodeAsync(studentCode);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(string studentCode, string bookId, int quantity)
        {
            var success = await _service.AddToCartAsync(studentCode, bookId, quantity);
            if (!success)
                return BadRequest("Không thể thêm vào giỏ. Có thể sách không tồn tại hoặc không còn bản sao khả dụng.");

            return Ok("Đã thêm sách vào giỏ.");
        }


        [HttpPut("update")]
        public async Task<IActionResult> UpdateQuantity(
     [FromQuery] string studentCode,
     [FromQuery] string bookId,
     [FromQuery] int quantity)
        {
            var success = await _service.UpdateQuantityAsync(studentCode, bookId, quantity);
            if (!success) return NotFound("Không tìm thấy sách trong giỏ.");
            return Ok();
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFromCart(string studentCode, string bookId)
        {
            var success = await _service.RemoveFromCartAsync(studentCode, bookId);
            if (!success) return NotFound("Không tìm thấy sách để xoá.");
            return Ok();
        }
        [HttpGet("total/{studentCode}")]
        public async Task<IActionResult> GetTotalQuantity(string studentCode)
        {
            var total = await _service.GetTotalQuantityAsync(studentCode);
            return Ok(new { totalQuantity = total });
        }

        [HttpDelete("clear/{studentCode}")]
        public async Task<IActionResult> ClearCart(string studentCode)
        {
            var success = await _service.ClearCartAsync(studentCode);
            if (!success) return NotFound("User not found or cart already empty.");

            return Ok("Cart cleared successfully.");
        }

    }
}
