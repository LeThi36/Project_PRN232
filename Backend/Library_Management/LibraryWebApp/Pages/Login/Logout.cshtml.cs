using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.Login
{
    public class LogoutModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public LogoutModel(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // 1. Lấy token từ cookie
            var token = HttpContext.Request.Cookies["AccessToken"];

            if (!string.IsNullOrEmpty(token))
            {
                var client = _httpClientFactory.CreateClient("ApiClient");

                // Đảm bảo BaseAddress được thiết lập trong HttpClientFactory
                // Hoặc thiết lập trực tiếp nếu cần
                // client.BaseAddress = new Uri(_configuration["ApiBaseUrl"] ?? "https://localhost:7092"); 

                // Thêm token vào header Authorization cho yêu cầu logout
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                // Gửi yêu cầu POST đến API logout
                var response = await client.PostAsync("api/auth/logout", null);

                if (response.IsSuccessStatusCode)
                {
                    // Xóa token khỏi cookie bất kể API trả về gì để đảm bảo người dùng được đăng xuất trên client
                    Response.Cookies.Delete("AccessToken", new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    });
                    return RedirectToPage("/Index"); // Chuyển hướng về trang chủ
                }
                else
                {
                    // Xử lý lỗi từ API nếu cần, có thể hiển thị thông báo lỗi
                    var errorContent = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Đăng xuất thất bại: {errorContent}");

                    // Vẫn xóa token khỏi cookie ngay cả khi API gặp lỗi để tránh lặp lại lỗi đăng xuất
                    Response.Cookies.Delete("AccessToken", new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    });
                    Response.Cookies.Delete("StudentCode", new CookieOptions
                    {
                        HttpOnly = false,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    });
                    return RedirectToPage("/Index"); // Vẫn chuyển hướng về trang đăng nhập
                }
            }

            // Nếu không có token trong cookie, đơn giản là xóa cookie (đề phòng) và chuyển hướng
            Response.Cookies.Delete("AccessToken", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });
            Response.Cookies.Delete("StudentCode", new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });
            return RedirectToPage("/Login/Login"); // Chuyển hướng về trang đăng nhập
        }
    }
}
