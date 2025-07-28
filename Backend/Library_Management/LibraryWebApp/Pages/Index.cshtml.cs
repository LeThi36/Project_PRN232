using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BussinessLayer.DTOs.Book;
using System.Net.Http;
using System.Net.Http.Json;
using LibraryWebApp.Handlers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

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

        public class ODataResponse<T>
        {
            public List<T> Value { get; set; } = new();
        }
    }
}
