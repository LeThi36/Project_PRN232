using BussinessLayer.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace LibraryWebApp.Pages.Profile
{
    public class UpdateProfileModel : PageModel
    {
        private readonly IHttpClientFactory _factory;

        public UpdateProfileModel(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        [BindProperty]
        public UpdateProfileDto ProfileData { get; set; } = new();

        public string? CurrentImageUrl { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        private HttpClient CreateAuthorizedClient()
        {
            var client = _factory.CreateClient("ApiClient");
            var token = HttpContext.Request.Cookies["AccessToken"];
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        public async Task OnGetAsync()
        {
            var client = CreateAuthorizedClient();
            var user = await client.GetFromJsonAsync<UserDto>("api/Users/profile");
            if (user != null)
            {
                ProfileData.PhoneNumber = user.PhoneNumber;
                ProfileData.DateOfBirth = user.DateOfBirth;
                ProfileData.Gender = user.Gender;
                ProfileData.Address = user.Address;
                CurrentImageUrl = user.ImageUrl; // This sets the current image URL
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                StatusMessage = "Invalid input data.";
                // When returning Page(), make sure CurrentImageUrl is set for display
                var clientOnPost = CreateAuthorizedClient();
                var userOnPost = await clientOnPost.GetFromJsonAsync<UserDto>("api/Users/profile");
                if (userOnPost != null)
                {
                    CurrentImageUrl = userOnPost.ImageUrl;
                }
                return Page();
            }

            var form = new MultipartFormDataContent();
            if (!string.IsNullOrEmpty(ProfileData.PhoneNumber))
                form.Add(new StringContent(ProfileData.PhoneNumber), "PhoneNumber");
            if (ProfileData.DateOfBirth.HasValue)
                form.Add(new StringContent(ProfileData.DateOfBirth.Value.ToString("yyyy-MM-dd")), "DateOfBirth");
            if (!string.IsNullOrEmpty(ProfileData.Gender))
                form.Add(new StringContent(ProfileData.Gender), "Gender");
            if (!string.IsNullOrEmpty(ProfileData.Address))
                form.Add(new StringContent(ProfileData.Address), "Address");

            if (ProfileData.ImageFile != null)
            {
                using var ms = new MemoryStream();
                await ProfileData.ImageFile.CopyToAsync(ms);
                var bytes = ms.ToArray();
                var byteContent = new ByteArrayContent(bytes);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(ProfileData.ImageFile.ContentType);
                form.Add(byteContent, "ImageFile", ProfileData.ImageFile.FileName);
            }

            var client = CreateAuthorizedClient();
            HttpResponseMessage resp;
            try
            {
                resp = await client.PutAsync("api/Users/profile", form);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Request failed: {ex.Message}";
                // If an error occurs, still try to load current image for display
                var clientOnError = CreateAuthorizedClient();
                var userOnError = await clientOnError.GetFromJsonAsync<UserDto>("api/Users/profile");
                if (userOnError != null)
                {
                    CurrentImageUrl = userOnError.ImageUrl;
                }
                return Page();
            }

            if (resp.IsSuccessStatusCode)
            {
                // After successful update, fetch the *latest* profile data
                // This ensures CurrentImageUrl is updated before rendering or redirecting
                var updatedUser = await client.GetFromJsonAsync<UserDto>("api/Users/profile");
                if (updatedUser != null)
                {
                    CurrentImageUrl = updatedUser.ImageUrl;
                    StatusMessage = "Profile updated successfully!";
                    return RedirectToPage(); // This will trigger OnGetAsync again, which will now have the correct URL
                }
                else
                {
                    StatusMessage = "Profile updated, but failed to retrieve updated data.";
                    // Fallback: If for some reason fetching updated user fails, still redirect to trigger OnGetAsync
                    return RedirectToPage();
                }
            }

            StatusMessage = $"Failed: {resp.ReasonPhrase}";
            // If the API call itself fails, ensure CurrentImageUrl is still populated
            var clientOnFail = CreateAuthorizedClient();
            var userOnFail = await clientOnFail.GetFromJsonAsync<UserDto>("api/Users/profile");
            if (userOnFail != null)
            {
                CurrentImageUrl = userOnFail.ImageUrl;
            }
            return Page();
        }
    }
}
