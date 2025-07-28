using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BussinessLayer.DTOs.Book;
using System.Net.Http;
using System.Net.Http.Json;
using LibraryWebApp.Handlers;

namespace LibraryWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public List<BookDto> FeaturedBooks { get; set; } = new();

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            try
            {
                var response = await client.GetAsync("api/Books");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<PagedResponse<BookDto>>();
                    if (result != null)
                    {
                        FeaturedBooks = result.Data.Take(6).ToList(); // sửa từ Value → Data
                    }
                }
                else
                {
                    _logger.LogError("❌ API call failed: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error calling API");
            }
        }


        public class ODataResponse<T>
        {
            public List<T> Value { get; set; } = new();
        }
    }
}
