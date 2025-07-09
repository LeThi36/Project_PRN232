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

        // Sử dụng BindProperty để liên kết dữ liệu từ form post với model này
        [BindProperty]
        public LoginRequest LoginRequest { get; set; }

        public LoginModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void OnGet()
        {
            // Trang chỉ hiển thị khi dùng phương thức GET
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // 1. Kiểm tra tính hợp lệ của model (ví dụ: các trường có được điền hay không)
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // 2. Tạo một HttpClient từ factory đã được cấu hình trong Program.cs
            var client = _httpClientFactory.CreateClient("ApiClient");

            // 3. Serialize đối tượng LoginRequest thành chuỗi JSON
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(LoginRequest),
                Encoding.UTF8,
                "application/json"
            );

            // 4. Gửi yêu cầu POST đến API
            var response = await client.PostAsync("api/auth/login", jsonContent);

            // 5. Xử lý kết quả trả về
            if (response.IsSuccessStatusCode)
            {
                // Đọc nội dung response
                var responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response để lấy token
                var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Giúp khớp với thuộc tính "accessToken" hoặc "AccessToken"
                });

                if (loginResponse?.AccessToken != null)
                {
                    // Lưu token vào một cookie bảo mật
                    // HttpOnly: Ngăn JavaScript phía client truy cập cookie, chống tấn công XSS
                    // Secure: Chỉ gửi cookie qua HTTPS
                    // SameSite.Strict: Chống tấn công CSRF
                    Response.Cookies.Append("AccessToken", loginResponse.AccessToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddMinutes(15) // Thời gian hết hạn của cookie
                    });

                    // Lưu StudentCode vào cookie
                    Response.Cookies.Append("StudentCode", LoginRequest.StudentCode, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(1)
                    });

                    // Đăng nhập thành công, chuyển hướng về trang chủ
                    return RedirectToPage("/Index");
                }
            }

            // Nếu đăng nhập thất bại, đọc lỗi từ API và hiển thị
            var errorContent = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, errorContent ?? "Đã xảy ra lỗi không xác định.");

            return Page();
        }
    }
}
