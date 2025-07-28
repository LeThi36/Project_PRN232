using BussinessLayer.DTOs.Author;
using BussinessLayer.DTOs.Book;
using BussinessLayer.DTOs.Category;
using BussinessLayer.DTOs.Publisher;
using DataLayer.Entities;
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

            var categoriesRaw = await client.GetFromJsonAsync<List<CategoryDto>>("api/Category") ?? new();
            Categories = categoriesRaw.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName
            }).ToList();

            var publishersRaw = await client.GetFromJsonAsync<List<PublisherResponseDto>>("api/Publishers") ?? new();
            Publishers = publishersRaw.Select(p => new SelectListItem
            {
                Value = p.Id,
                Text = p.PublisherName
            }).ToList();

            var authorsRaw = await client.GetFromJsonAsync<List<Author>>("api/Author") ?? new();
            Authors = authorsRaw.Select(a => new SelectListItem
            {
                Value = a.Id,
                Text = a.AuthorName
            }).ToList();
        }
    }
}
