using BussinessLayer.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowOrdersController : ControllerBase
    {
        private readonly IBorrowOrderService _borrowOrderService;

        public BorrowOrdersController(IBorrowOrderService borrowOrderService)
        {
            _borrowOrderService = borrowOrderService;
        }

        // POST: api/borroworders/checkout/{studentCode}
        [HttpPost("checkout/{studentCode}")]
        public async Task<IActionResult> CheckoutCart(string studentCode)
        {
            try
            {
                var result = await _borrowOrderService.CheckoutCartAsync(studentCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/borroworders/approve/{orderId}
        [HttpPut("approve/{orderId}")]
        public async Task<IActionResult> ApproveOrder(string orderId)
        {
            try
            {
                await _borrowOrderService.ApproveBorrowOrderAsync(orderId);
                return Ok("Order approved successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/borroworders/return/{recordId}
        [HttpPut("return/{recordId}")]
        public async Task<IActionResult> ReturnBook(string recordId)
        {
            try
            {
                await _borrowOrderService.ReturnBookAsync(recordId);
                return Ok("Book returned successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/borroworders/student/{studentCode}
        [HttpGet("student/{studentCode}")]
        public async Task<IActionResult> GetOrdersByStudent(string studentCode)
        {
            try
            {
                var orders = await _borrowOrderService.GetOrdersByStudentAsync(studentCode);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cancel/{id}")]
        public async Task<IActionResult> CancelBorrowOrder(string id)
        {
            var result = await _borrowOrderService.CancelBorrowOrderAsync(id);
            if (!result)
                return BadRequest("Không thể hủy phiếu mượn.");

            return Ok(new { message = "Đã hủy phiếu mượn và cập nhật sách." });
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _borrowOrderService.GetAllOrdersAsync();
            return Ok(orders);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchOrders([FromQuery] string? studentCode, [FromQuery] string? status)
        {
            var result = await _borrowOrderService.SearchOrdersAsync(studentCode, status);
            return Ok(result);
        }
    }   
}
