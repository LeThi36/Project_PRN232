using System.Net.Http.Headers;
using System.Text.Json;
using BussinessLayer.DTOs.BorrowRecord;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.BorrowOrder
{
    public class HistoryModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HistoryModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<BorrowOrderDto> BorrowOrders { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var studentCode = Request.Cookies["StudentCode"];
            var token = Request.Cookies["AccessToken"];

            if (string.IsNullOrEmpty(studentCode) || string.IsNullOrEmpty(token))
                return RedirectToPage("/Login");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"https://localhost:7092/api/BorrowOrders/student/{studentCode}");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Không thể tải dữ liệu phiếu mượn!";
                return Page();
            }

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            BorrowOrders = JsonSerializer.Deserialize<List<BorrowOrderDto>>(json, options) ?? new List<BorrowOrderDto>();

            return Page();
        }
    }
}
