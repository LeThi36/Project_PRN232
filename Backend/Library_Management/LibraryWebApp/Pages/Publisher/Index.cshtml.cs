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
        public PublisherCreateDto NewPublisher { get; set; } = new();


        public List<PublisherResponseDto> Publishers { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty(SupportsGet = true, Name = "pageIndex")]
        public int Page { get; set; } = 1;

        public int TotalPages { get; set; }

        public int PageSize { get; set; } = 5;

        public async Task OnGetAsync()
        {
            var result = await _publisherService.GetPagedPublishersAsync(Search, Page, PageSize);

            Publishers = result.Data.Select(p => new PublisherResponseDto
            {
                Id = p.Id,
                PublisherName = p.PublisherName,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToList();

            TotalPages = (int)Math.Ceiling(result.TotalCount / (double)PageSize);
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            ModelState.Remove(nameof(Search));

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();

                TempData["StatusMessage"] = "Invalid data: " + string.Join(" | ", errors);
                TempData["ShowCreateModal"] = "true";
                await OnGetAsync();
                return Page();
            }

            try
            {
                await _publisherService.AddPublisher(NewPublisher);
                TempData["StatusMessage"] = "Publisher created successfully.";
                return RedirectToPage(new { search = Search, pageIndex = Page });
            }
            catch (Exception ex)
            {
                TempData["StatusMessage"] = $"Failed to create publisher: {ex.Message}";
                TempData["ShowCreateModal"] = "true";
                await OnGetAsync();
                return Page();
            }
        }


        public async Task<IActionResult> OnPostEditAsync()
        {
            var form = Request.Form;

            // Lấy dữ liệu thủ công
            string id = form["Publisher.Id"];
            string name = form["Publisher.PublisherName"];
            string address = form["Publisher.Address"];
            string phone = form["Publisher.PhoneNumber"];

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
            {
                StatusMessage = "Invalid publisher data.";
                await OnGetAsync();
                return Page();
            }

            try
            {
                var updateDto = new PublisherUpdateDto
                {
                    PublisherName = name,
                    Address = address,
                    PhoneNumber = phone
                };

                await _publisherService.UpdatePublisher(id, updateDto);
                StatusMessage = "Publisher updated successfully.";
                return RedirectToPage(new { search = Search, pageIndex = Page });
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to update publisher: {ex.Message}";
                await OnGetAsync();
                return Page();
            }
        }



        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                StatusMessage = "Publisher ID is required.";
                return RedirectToPage(new { search = Search, pageIndex = Page });
            }

            try
            {
                await _publisherService.RemovePublisher(id);
                StatusMessage = "Publisher deleted successfully.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"This publisher cannot be deleted.";
            }

            return RedirectToPage(new { search = Search, pageIndex = Page });
        }


    }
}
