using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;
using BussinessLayer.DTOs.Authentication;

namespace LibraryWebApp.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        [BindProperty]
        public LoginRequest LoginRequest { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public LoginModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            var json = new StringContent(
                JsonSerializer.Serialize(LoginRequest),
                Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/auth/login", json);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var loginRes = JsonSerializer.Deserialize<LoginResponse>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (loginRes?.AccessToken != null)
                {
                    // Xóa cookie cũ rồi lưu token mới
                    Response.Cookies.Delete("AccessToken");
                    Response.Cookies.Append("AccessToken", loginRes.AccessToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Lax,
                        Path = "/",
                        Expires = DateTimeOffset.UtcNow.AddMinutes(30)
                    });

                    // Lưu StudentCode
                    Response.Cookies.Delete("StudentCode");
                    Response.Cookies.Append("StudentCode", LoginRequest.StudentCode, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Lax,
                        Path = "/",
                        Expires = DateTimeOffset.UtcNow.AddHours(1)
                    });

                    return RedirectToPage("/Index");
                }
            }

            var err = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, err);
            return Page();
        }
    }
}
