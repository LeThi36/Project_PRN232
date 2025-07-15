using BussinessLayer.DTOs.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Json;

namespace LibraryWebApp.Pages.Book
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public UpdateBookDto Book { get; set; } = new();

        public List<SelectListItem> Authors { get; set; } = new();
        public List<SelectListItem> Categories { get; set; } = new();
        public List<SelectListItem> Publishers { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var book = await client.GetFromJsonAsync<BookDto>($"api/Books/{id}");

            if (book == null) return NotFound();

            Book = new UpdateBookDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                PublisherId = book.PublisherId,
                PublicationYear = book.PublicationYear,
                Status = book.Status,
                ImageUrl = book.ImageUrl
            };

            await LoadDropdownsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync();
                return Page();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.PutAsJsonAsync($"api/Books/{Book.Id}", Book);

            if (response.IsSuccessStatusCode)
                return RedirectToPage("Index");

            ModelState.AddModelError("", "Update failed.");
            await LoadDropdownsAsync();
            return Page();
        }

        private async Task LoadDropdownsAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            Authors = await client.GetFromJsonAsync<List<SelectListItem>>("api/author") ?? new();
            //Categories = await client.GetFromJsonAsync<List<SelectListItem>>("api/Categories") ?? new();
            //Publishers = await client.GetFromJsonAsync<List<SelectListItem>>("api/Publishers") ?? new();
        }
    }
}
