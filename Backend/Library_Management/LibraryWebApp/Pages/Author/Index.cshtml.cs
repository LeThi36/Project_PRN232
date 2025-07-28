using BussinessLayer.DTOs.Author;
using BussinessLayer.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.Author
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _apiClient;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _apiClient = httpClientFactory.CreateClient("ApiClient");
        }

        [BindProperty]
        public AuthorDto NewAuthor { get; set; } = new AuthorDto();

        public List<AuthorResponseDto> Authors { get; set; } = new();

        [TempData]
        public string StatusMessage { get; set; }

        public async Task OnGetAsync()
        {
            Authors = await _apiClient.GetFromJsonAsync<List<AuthorResponseDto>>("api/Author");
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                StatusMessage = "Invalid data.";
                return RedirectToPage();
            }

            var response = await _apiClient.PostAsJsonAsync("api/Author", NewAuthor);
            if (response.IsSuccessStatusCode)
            {
                StatusMessage = "Author created successfully.";
            }
            else
            {
                StatusMessage = $"Failed to create author: {response.ReasonPhrase}";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(string id, string authorName)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(authorName))
            {
                StatusMessage = "Invalid data.";
                return RedirectToPage();
            }

            var dto = new AuthorDto { AuthorName = authorName };
            var response = await _apiClient.PutAsJsonAsync($"api/Author/{id}", dto);
            if (response.IsSuccessStatusCode)
            {
                StatusMessage = "Author updated successfully.";
            }
            else
            {
                StatusMessage = $"Failed to update author: {response.ReasonPhrase}";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                StatusMessage = "Invalid ID.";
                return RedirectToPage();
            }

            var response = await _apiClient.DeleteAsync($"api/Author/{id}");
            if (response.IsSuccessStatusCode)
            {
                StatusMessage = "Author deleted successfully.";
            }
            else
            {
                StatusMessage = $"Failed to delete author: {response.ReasonPhrase}";
            }

            return RedirectToPage();
        }
    }
}
