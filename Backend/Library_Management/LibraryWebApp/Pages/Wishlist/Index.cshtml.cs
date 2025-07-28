    using BussinessLayer.DTOs.BookFavorite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace LibraryWebApp.Pages.Wishlist
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public List<BookFavoriteDto> WishlistItems { get; set; } = new();
        [TempData]
        public string? Message { get; set; }

        public IndexModel(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var studentCode = Request.Cookies["StudentCode"];
            var token = Request.Cookies["AccessToken"];

            if (string.IsNullOrEmpty(studentCode) || string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Login/Login");
            }

            var apiBaseUrl = _configuration["ApiBaseUrl"]; // Lấy từ appsettings.json

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"{apiBaseUrl}/api/BookFavorites/student/{studentCode}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                WishlistItems = JsonSerializer.Deserialize<List<BookFavoriteDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAddToCartAsync(string bookId)
        {
            var studentCode = Request.Cookies["StudentCode"];
            var token = Request.Cookies["AccessToken"];
            if (string.IsNullOrEmpty(studentCode) || string.IsNullOrEmpty(token)) return RedirectToPage("/Login/Login");

            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsync($"{apiBaseUrl}/api/Cart/add?studentCode={studentCode}&bookId={bookId}&quantity=1", null);
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Sách đã được thêm vào giỏ hàng.";
            }
            else
            {
                TempData["ErrorMessage"] = "Không thể thêm sách vào giỏ hàng. Hết Sách.";
            }

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostRemoveAsync(string bookId)
        {
            var studentCode = Request.Cookies["StudentCode"];
            var token = Request.Cookies["AccessToken"];
            if (string.IsNullOrEmpty(studentCode) || string.IsNullOrEmpty(token))
                return RedirectToPage("/Login/Login");

            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.DeleteAsync($"{apiBaseUrl}/api/BookFavorites/{bookId}/student/{studentCode}");

            if (!response.IsSuccessStatusCode)
            {
                // Ghi log hoặc xử lý lỗi tại đây nếu cần
            }

            return RedirectToPage(); // Tải lại trang sau khi xóa
        }
    }

}
