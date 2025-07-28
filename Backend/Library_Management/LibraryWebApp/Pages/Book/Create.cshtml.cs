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
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CreateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public CreateBookDto Book { get; set; } = new();

        public List<SelectListItem> Authors { get; set; } = new();
        public List<SelectListItem> Categories { get; set; } = new();
        public List<SelectListItem> Publishers { get; set; } = new();

        public async Task OnGetAsync()
        {
            await LoadDropdownsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync();
                return Page();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.PostAsJsonAsync("api/Books", Book);

            if (response.IsSuccessStatusCode)
                return RedirectToPage("Index");

            ModelState.AddModelError("", "Failed to create book.");
            await LoadDropdownsAsync();
            return Page();
        }

        private async Task LoadDropdownsAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            // Categories
            var categoriesRaw = await client.GetFromJsonAsync<List<CategoryDto>>("api/Category") ?? new();
            Categories = categoriesRaw.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName
            }).ToList();

            // Publishers
            var publishersRaw = await client.GetFromJsonAsync<List<PublisherResponseDto>>("api/Publishers") ?? new();
            Publishers = publishersRaw.Select(p => new SelectListItem
            {
                Value = p.Id,
                Text = p.PublisherName
            }).ToList();

            // Authors (nếu có)
            var authorsRaw = await client.GetFromJsonAsync<List<AuthorResponseDto>>("api/Author") ?? new();
            Authors = authorsRaw.Select(a => new SelectListItem
            {
                Value = a.Id,
                Text = a.AuthorName
            }).ToList();
        }

    }
}
