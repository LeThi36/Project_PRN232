using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace LibraryWebApp.Pages.Login
{
    public class LogoutModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LogoutModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var token = Request.Cookies["AccessToken"];
            if (!string.IsNullOrEmpty(token))
            {
                var client = _httpClientFactory.CreateClient("ApiClient");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                await client.PostAsync("api/auth/logout", null);
            }

            // Xóa cookie bất kể kết quả API
            Response.Cookies.Delete("AccessToken");
            Response.Cookies.Delete("StudentCode");
            return RedirectToPage("/Login/Login");
        }
    }
}
