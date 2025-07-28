using BussinessLayer.DTOs.Book;
using LibraryWebApp.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace LibraryWebApp.Pages.Book
{
    public class BookSearchModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BookSearchModel> _logger;
        private readonly string _apiBaseUrl;

        public List<BookDto> Books { get; set; } = new();
        public List<SelectListItem> Authors { get; set; } = new();
        public List<SelectListItem> Categories { get; set; } = new();
        public List<SelectListItem> Publishers { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? AuthorId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CategoryId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? PublisherId { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool IncludeDeleted { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        public int TotalPages { get; set; }
        public int CurrentPage => PageNumber;

        public string ApiBaseUrl => _apiBaseUrl;

        public BookSearchModel(IHttpClientFactory httpClientFactory, ILogger<BookSearchModel> logger, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _apiBaseUrl = config["ApiBaseUrl"]!;
        }

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl);

            var query = new StringBuilder("api/Books?");
            if (!string.IsNullOrWhiteSpace(SearchTerm)) query.Append($"SearchTerm={SearchTerm}&");
            if (!string.IsNullOrWhiteSpace(AuthorId)) query.Append($"AuthorId={AuthorId}&");
            if (!string.IsNullOrWhiteSpace(CategoryId)) query.Append($"CategoryId={CategoryId}&");
            if (!string.IsNullOrWhiteSpace(PublisherId)) query.Append($"PublisherId={PublisherId}&");
            if (IncludeDeleted) query.Append("IncludeDeleted=true&");

            query.Append($"PageNumber={PageNumber}&PageSize={PageSize}");

            try
            {
                var res = await client.GetAsync(query.ToString());
                if (res.IsSuccessStatusCode)
                {
                    var result = await res.Content.ReadFromJsonAsync<PagedResponse<BookDto>>();
                    if (result is not null)
                    {
                        Books = result.Data;
                        TotalPages = result.TotalPages;
                    }
                }

                Authors = await LoadSelectItems(client, "api/Author");
                Categories = await LoadSelectItems(client, "api/Category");
                Publishers = await LoadSelectItems(client, "api/Publishers");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading book filters or data.");
            }
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
    }
}
