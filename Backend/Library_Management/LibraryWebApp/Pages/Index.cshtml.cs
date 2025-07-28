using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BussinessLayer.DTOs.Book;
using System.Net.Http;
using System.Net.Http.Json;
using LibraryWebApp.Handlers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl;

        public List<BookDto> FeaturedBooks { get; set; } = new();
        public List<SelectListItem> Categories { get; set; } = new();
        public Dictionary<string, BookDto> CategoryWithBook { get; set; } = new();

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = configuration["ApiBaseUrl"]!;
        }

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            try
            {
                // Load featured books
                var response = await client.GetAsync("api/Books");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<PagedResponse<BookDto>>();
                    if (result != null)
                    {
                        FeaturedBooks = result.Data.Take(6).ToList();
                    }
                }
                else
                {
                    _logger.LogError("API call failed: {StatusCode}", response.StatusCode);
                }

                // Load categories
                Categories = await LoadSelectItems(client, "api/Category");

                // Load 1 book per category
                foreach (var category in Categories)
                {
                    var categoryId = category.Value;
                    var bookRes = await client.GetAsync($"api/Books?CategoryId={categoryId}&PageSize=1");

                    if (bookRes.IsSuccessStatusCode)
                    {
                        var bookResult = await bookRes.Content.ReadFromJsonAsync<PagedResponse<BookDto>>();
                        if (bookResult != null && bookResult.Data.Any())
                        {
                            CategoryWithBook[category.Text] = bookResult.Data.First();
                        }
                        else
                        {
                            CategoryWithBook[category.Text] = null!;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling API");
            }
        }

        private async Task<List<SelectListItem>> LoadSelectItems(HttpClient client, string endpoint)
        {
            var items = new List<SelectListItem>();
            try
            {
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(json);
                    foreach (var item in doc.RootElement.EnumerateArray())
                    {
                        var id = item.GetProperty("id").GetString();
                        var name = item.EnumerateObject().FirstOrDefault(p => p.Name.ToLower().Contains("name")).Value.GetString();
                        items.Add(new SelectListItem { Value = id, Text = name });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"Failed to load {endpoint}");
            }
            return items;
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string bookId)
        {
            var studentCode = Request.Cookies["StudentCode"];
            var token = Request.Cookies["AccessToken"];

            if (string.IsNullOrEmpty(studentCode) || string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Login/Login");
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.PostAsync($"{_apiBaseUrl}/api/Cart/add?studentCode={studentCode}&bookId={bookId}&quantity=1", null);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Add to cart failed: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding book to cart");
            }

            return RedirectToPage(); // Reload Index page
        }

        public async Task<IActionResult> OnPostAddToWishlistAsync(string bookId)
        {
            var token = Request.Cookies["AccessToken"];
            // Redirect to login if no access token.
            // This is crucial as the API requires authentication.
            if (string.IsNullOrEmpty(token))
                return RedirectToPage("/Login/Login");

            var apiBaseUrl = _apiBaseUrl; // Ensure _apiBaseUrl is correctly configured
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // Create an anonymous object matching the BookFavoriteCreateDto structure
            var dto = new
            {
                BookId = bookId // Only send BookId
            };

            var content = new StringContent(JsonSerializer.Serialize(dto), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiBaseUrl}/api/BookFavorites", content);

            if (!response.IsSuccessStatusCode)
            {
                // Handle API errors, e.g., log them or display a message to the user
                _logger.LogWarning("Add to wishlist failed: {StatusCode}. Response: {ResponseBody}", response.StatusCode, await response.Content.ReadAsStringAsync());
                TempData["ErrorMessage"] = "Đã thêm sách vào yêu thích <3";
            }
            else
            {
                TempData["ErrorMessage"] = "Thêm sách vào yêu thích thất bại. Vui lòng thử lại.";
            }

                return RedirectToPage(); // reload the current page
        }
        public class ODataResponse<T>
        {
            public List<T> Value { get; set; } = new();
        }
    }
}
