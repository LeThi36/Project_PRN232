using BussinessLayer.DTOs.BorrowRecord;
using BussinessLayer.Services;
using BussinessLayer.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowRecordsController : ControllerBase
    {
        private readonly IBorrowService _service;

        public BorrowRecordsController(IBorrowService service)
        {
            _service = service;
        }

        // Student gửi yêu cầu
        [HttpPost("request")]
        public async Task<IActionResult> RequestBorrow([FromBody] BorrowRequestDto dto)
        {
            var result = await _service.RequestBorrowAsync(dto);
            return Ok(result);
        }

        // Librarian xác nhận
        [HttpPost("approve")]
        public async Task<IActionResult> ApproveBorrow([FromBody] BorrowApprovalDto dto)
        {
            var result = await _service.ApproveBorrowAsync(dto);
            return Ok(result);
        }

        // Student xem danh sách mượn
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserBorrows(string userId)
        {
            var result = await _service.GetByUserIdAsync(userId);
            return Ok(result);
        }
        // ✅ Student huỷ yêu cầu mượn (nếu chưa được Librarian duyệt)
        [HttpDelete("{id}/cancel")]
        public async Task<IActionResult> CancelBorrowRequest(string id, [FromQuery] string userId)
        {
            try
            {
                await _service.CancelBorrowRequestAsync(id, userId);
                return Ok(new { message = "Borrow request canceled successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        // librarian cho mượn sách
        [HttpPost("librarian/create")]
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> CreateByLibrarian([FromBody] BorrowCreateDto dto)
        {
            try
            {
                var result = await _service.CreateBorrowByLibrarianAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
