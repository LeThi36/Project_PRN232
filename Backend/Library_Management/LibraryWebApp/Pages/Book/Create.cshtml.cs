using BussinessLayer.DTOs.Book;
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

            Authors = await client.GetFromJsonAsync<List<SelectListItem>>("api/author") ?? new();
            //Categories = await client.GetFromJsonAsync<List<SelectListItem>>("api/Categories/dropdown") ?? new();
            //Publishers = await client.GetFromJsonAsync<List<SelectListItem>>("api/Publishers/dropdown") ?? new();
        }
    }
}
