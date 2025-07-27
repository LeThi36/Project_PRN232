using BussinessLayer.DTOs.Book;
using LibraryWebApp.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<IndexModel> _logger;
        private readonly string _apiBaseUrl;

        public List<BookDto> Books { get; set; } = new();

        public string ApiBaseUrl => _apiBaseUrl;

        public IndexModel(IHttpClientFactory httpClientFactory, ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _apiBaseUrl = configuration["ApiBaseUrl"]!;
        }

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl);

            try
            {
                var response = await client.GetAsync("api/Books?pageNumber=1&pageSize=100");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<PagedResponse<BookDto>>();
                    Books = result?.Data ?? new();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch books.");
            }
        }
    }
}
