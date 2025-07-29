using BussinessLayer.DTOs.Publisher;
using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        /// <summary>
        /// Lấy tất cả nhà xuất bản.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "0,1,2")]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publishers = await _publisherService.GetAllPublisher();

            var responseDtos = publishers.Select(p => new PublisherResponseDto
            {
                Id = p.Id,
                PublisherName = p.PublisherName,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToList();

            return Ok(responseDtos);
        }

        /// <summary>
        /// Lấy một nhà xuất bản theo ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "0,1,2")]
        public async Task<IActionResult> GetPublisherById(string id)
        {
            try
            {
                var publisher = await _publisherService.GetPublisherById(id);
                var dto = new PublisherResponseDto
                {
                    Id = publisher.Id,
                    PublisherName = publisher.PublisherName,
                    Address = publisher.Address,
                    PhoneNumber = publisher.PhoneNumber,
                    CreatedAt = publisher.CreatedAt,
                    UpdatedAt = publisher.UpdatedAt
                };
                return Ok(dto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Tạo một nhà xuất bản mới.
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "0")]
        public async Task<IActionResult> AddPublisher([FromBody] PublisherCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _publisherService.AddPublisher(dto);
                var response = new PublisherResponseDto
                {
                    Id = created.Id,
                    PublisherName = created.PublisherName,
                    Address = created.Address,
                    PhoneNumber = created.PhoneNumber,
                    CreatedAt = created.CreatedAt,
                    UpdatedAt = created.UpdatedAt
                };

                return CreatedAtAction(nameof(GetPublisherById), new { id = created.Id }, response);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating publisher: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật thông tin nhà xuất bản.
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "0")]
        public async Task<IActionResult> UpdatePublisher(string id, [FromBody] PublisherUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrEmpty(id) || dto == null)
                return BadRequest("Invalid ID or data.");

            try
            {
                await _publisherService.UpdatePublisher(id, dto);
                return NoContent();
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
                return StatusCode(500, $"Error updating publisher: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa một nhà xuất bản.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "0")]
        public async Task<IActionResult> RemovePublisher(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Publisher ID cannot be null or empty.");

            try
            {
                await _publisherService.RemovePublisher(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting publisher: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách nhà xuất bản có phân trang và tìm kiếm.
        /// </summary>
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedPublishers(
            [FromQuery] string? search,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 5)
        {
            var result = await _publisherService.GetPagedPublishersAsync(search, pageIndex, pageSize);

            var response = new PaginationResult<PublisherResponseDto>(
                result.Data.Select(p => new PublisherResponseDto
                {
                    Id = p.Id,
                    PublisherName = p.PublisherName,
                    Address = p.Address,
                    PhoneNumber = p.PhoneNumber,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                }),
                result.TotalCount,
                result.PageIndex,
                result.PageSize
            );

            return Ok(response);
        }


    }
}
