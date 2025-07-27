using BussinessLayer.DTOs.Cart;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public List<CartItemDto> CartItems { get; set; } = new();
        public int TotalQuantity { get; set; }

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
                return RedirectToPage("/Login/Login");

            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"{apiBaseUrl}/api/Cart/{studentCode}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                CartItems = JsonSerializer.Deserialize<List<CartItemDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
            }

            var totalResponse = await client.GetFromJsonAsync<TotalResponse>($"{apiBaseUrl}/api/Cart/total/{studentCode}");
            TotalQuantity = totalResponse?.TotalQuantity ?? 0;

            return Page();
        }

        public class TotalResponse
        {
            public int TotalQuantity { get; set; }
        }
    }
}
