using BussinessLayer.DTOs;
using BussinessLayer.DTOs.BookCopy;
using BussinessLayer.DTOs.NewFolder1;
using BussinessLayer.Services;
using BussinessLayer.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCopiesController : ControllerBase
    {
        private readonly IBookCopyService _service;

        public BookCopiesController(IBookCopyService service)
        {
            _service = service;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCopyCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            var response = new BookCopyResponseDto
            {
                Id = result.Id,
                BookId = result.BookId,
                CopyCode = result.CopyCode,
                Status = result.Status,
                CreatedAt = result.CreatedAt
            };
            return CreatedAtAction(nameof(GetByBookId), new { bookId = result.BookId }, response);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] BookCopyUpdateDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        // GET: api/BookCopies/by-book/{bookId}
        [HttpGet("by-book/{bookId}")]
        public async Task<IActionResult> GetByBookId(string bookId)
        {
            var list = await _service.GetByBookIdAsync(bookId);
            var result = list.Select(c => new BookCopyResponseDto
            {
                Id = c.Id,
                CopyCode = c.CopyCode,
                Status = c.Status,
                BookId = c.BookId,
                CreatedAt = c.CreatedAt
            }).ToList();

            return Ok(result);
        }
        
        [HttpGet("available/{bookId}")]
        public async Task<IActionResult> GetAvailableCopies(string bookId)
        {
            var available = await _service.GetAvailableCopiesAsync(bookId);
            return Ok(available);
        }
    

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
    [FromQuery] string bookId,
    [FromQuery] string? search,
    [FromQuery] string? status,
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 5)
        {
            var pagedResult = await _service.GetPagedAsync(bookId, search, status, page, pageSize);

            // Map to PaginationResult<T>
            var result = new PaginationResult<BookCopyResponseDto>(
                pagedResult.Data,
                pagedResult.TotalCount,
                pagedResult.PageNumber,
                pagedResult.PageSize
            );

            return Ok(result);
        }

    }
}
