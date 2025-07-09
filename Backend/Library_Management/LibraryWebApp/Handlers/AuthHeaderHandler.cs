using System.Net.Http.Headers;

namespace LibraryWebApp.Handlers
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthHeaderHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Lấy token từ cookie của request hiện tại
            var token = _httpContextAccessor.HttpContext?.Request.Cookies["AccessToken"];

            if (!string.IsNullOrEmpty(token))
            {
                // Thêm token vào header Authorization của request gửi đi
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
