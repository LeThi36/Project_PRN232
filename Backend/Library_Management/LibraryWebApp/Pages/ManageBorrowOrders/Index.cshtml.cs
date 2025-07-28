
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using BussinessLayer.DTOs.BorrowRecord;

namespace LibraryWebApp.Pages.ManageBorrowOrders
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IHttpClientFactory httpClientFactory, ILogger<IndexModel> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string StudentCode { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Status { get; set; }

        public List<BorrowOrderDto> BorrowOrders { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var token = Request.Cookies["AccessToken"];

                if (string.IsNullOrEmpty(token))
                    return RedirectToPage("/Login");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string apiUrl = "https://localhost:7092/api/borroworders";

                if (!string.IsNullOrEmpty(StudentCode) || !string.IsNullOrEmpty(Status))
                {
                    apiUrl += $"/search?studentCode={StudentCode}&status={Status}";
                }
                else
                {
                    apiUrl += "/all";
                }

                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    BorrowOrders = JsonSerializer.Deserialize<List<BorrowOrderDto>>(json, options) ?? new();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching borrow orders.");
            }

            return Page();
        }
    }
}
