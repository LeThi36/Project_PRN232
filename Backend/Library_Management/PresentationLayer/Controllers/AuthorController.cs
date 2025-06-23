using BussinessLayer.DTOs.Author;
using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/Author
        /// <summary>
        /// Lấy tất cả tác giả.
        /// </summary>
        /// <returns>Danh sách các tác giả.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthor();
            // CHỈNH SỬA DÒNG NÀY: Ánh xạ sang AuthorResponseDto
            var authorResponseDtos = authors.Select(a => new AuthorResponseDto
            {
                Id = a.Id,
                AuthorName = a.AuthorName,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt
            }).ToList();
            return Ok(authorResponseDtos);
        }

        // GET: api/Author/{id}
        /// <summary>
        /// Lấy một tác giả theo ID.
        /// </summary>
        /// <param name="id">ID của tác giả.</param>
        /// <returns>Thông tin tác giả.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(string id)
        {
            try
            {
                var author = await _authorService.GetAuthorById(id);
                // Chuyển đổi từ Author entity sang AuthorDto
                var authorDto = new AuthorDto { AuthorName = author.AuthorName /* Thêm các trường khác nếu có */ };
                return Ok(authorDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Author
        /// <summary>
        /// Thêm một tác giả mới.
        /// </summary>
        /// <param name="authorDto">Dữ liệu tác giả cần thêm.</param>
        /// <returns>Kết quả tạo tác giả.</returns>
        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Sau khi IAuthorService và AuthorService đã được cập nhật để trả về Author
                var createdAuthor = await _authorService.AddAuthor(authorDto);
                var responseDto = new AuthorResponseDto
                {
                    Id = createdAuthor.Id,
                    AuthorName = createdAuthor.AuthorName,
                    CreatedAt = createdAuthor.CreatedAt,
                    UpdatedAt = createdAuthor.UpdatedAt
                };
                return CreatedAtAction(nameof(GetAuthorById), new { id = createdAuthor.Id }, responseDto);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating author: {ex.Message}");
            }
        }

        // PUT: api/Author/{id}
        /// <summary>
        /// Cập nhật thông tin một tác giả.
        /// </summary>
        /// <param name="id">ID của tác giả cần cập nhật.</param>
        /// <param name="authorDto">Dữ liệu tác giả đã cập nhật.</param>
        /// <returns>Kết quả cập nhật.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(string id, [FromBody] AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(id) || authorDto == null)
            {
                return BadRequest("Invalid author ID or data.");
            }

            try
            {
                await _authorService.UpdateAuthor(id, authorDto);
                return NoContent(); // Cập nhật thành công, không trả về nội dung
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating author: {ex.Message}");
            }
        }

        // DELETE: api/Author/{id}
        /// <summary>
        /// Xóa một tác giả.
        /// </summary>
        /// <param name="id">ID của tác giả cần xóa.</param>
        /// <returns>Kết quả xóa.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAuthor(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Author ID cannot be null or empty.");
            }

            try
            {
                await _authorService.RemoveAuthor(id);
                return NoContent(); // Xóa thành công, không trả về nội dung
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting author: {ex.Message}");
            }
        }
    }
}
