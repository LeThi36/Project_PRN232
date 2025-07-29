using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;
using BussinessLayer.DTOs.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
                return Page();

            var client = _httpClientFactory.CreateClient("ApiClient");
            var json = new StringContent(
                JsonSerializer.Serialize(LoginRequest),
                Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/auth/login", json);
            if (!response.IsSuccessStatusCode)
            {
                var err = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, err);
                return Page();
            }

            var body = await response.Content.ReadAsStringAsync();
            var loginRes = JsonSerializer.Deserialize<LoginResponse>(body, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (loginRes?.AccessToken is null)
            {
                ModelState.AddModelError(string.Empty, "Authentication failed.");
                return Page();
            }

            // 1. Lưu token vào cookie
            Response.Cookies.Delete("AccessToken");
            Response.Cookies.Append("AccessToken", loginRes.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Path = "/",
                Expires = DateTimeOffset.UtcNow.AddMinutes(30)
            });

            // 2. (Nếu cần) lưu thêm thông tin student code
            Response.Cookies.Delete("StudentCode");
            Response.Cookies.Append("StudentCode", LoginRequest.StudentCode, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Path = "/",
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });

            // 3. Đọc role từ JWT
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(loginRes.AccessToken);
            var roleClaim = jwt.Claims.FirstOrDefault(c =>
                   c.Type == ClaimTypes.Role || c.Type == "role")?.Value;

            // 4. Redirect theo role
            if (roleClaim != null &&
                (roleClaim.Equals("0", StringComparison.OrdinalIgnoreCase)
              || roleClaim.Equals("1", StringComparison.OrdinalIgnoreCase)))
            {
                // Về trang quản lý sách
                return RedirectToPage("/Book/Index");
            }
            else
            {
                // Về trang chung cho student
                return RedirectToPage("/Index");
            }
        }
    }
}
