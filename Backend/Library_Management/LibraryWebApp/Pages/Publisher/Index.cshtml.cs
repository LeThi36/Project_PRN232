using BussinessLayer.DTOs.Publisher;
using BussinessLayer.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.Publisher
{
    public class IndexModel : PageModel
    {
        private readonly IPublisherService _publisherService;

        public IndexModel(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [BindProperty]
        public PublisherCreateDto Publisher { get; set; }

        public List<PublisherResponseDto> Publishers { get; set; }

        [TempData]
        public string StatusMessage { get; set; } // hiển thị thông báo

        public async Task OnGetAsync()
        {
            var result = await _publisherService.GetAllPublisher();
            Publishers = result.Select(p => new PublisherResponseDto
            {
                Id = p.Id,
                PublisherName = p.PublisherName,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToList();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                StatusMessage = "Invalid data.";
                return RedirectToPage();
            }

            try
            {
                await _publisherService.AddPublisher(Publisher);
                StatusMessage = "Publisher created successfully.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to create publisher: {ex.Message}";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync([FromForm] PublisherResponseDto publisher)
        {
            if (!ModelState.IsValid || publisher == null || string.IsNullOrEmpty(publisher.Id))
            {
                StatusMessage = "Invalid publisher data.";
                return RedirectToPage();
            }

            try
            {
                var updateDto = new PublisherUpdateDto
                {
                    PublisherName = publisher.PublisherName,
                    Address = publisher.Address,
                    PhoneNumber = publisher.PhoneNumber
                };

                await _publisherService.UpdatePublisher(publisher.Id, updateDto);
                StatusMessage = "Publisher updated successfully.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to update publisher: {ex.Message}";
            }

            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                StatusMessage = "Publisher ID is required.";
                return RedirectToPage();
            }

            try
            {
                await _publisherService.RemovePublisher(id);
                StatusMessage = "Publisher deleted successfully.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to delete publisher: {ex.Message}";
            }

            return RedirectToPage();
        }

    }
}
