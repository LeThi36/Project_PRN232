using System.Text.Json;
using BussinessLayer.DTOs.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<CategoryDto> Categories { get; set; } = new();

        [BindProperty]
        public string NewCategoryName { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.GetAsync("/api/Category");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return RedirectToPage("/Login/Login");
            }

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Categories = JsonSerializer.Deserialize<List<CategoryDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (string.IsNullOrWhiteSpace(NewCategoryName))
            {
                TempData["StatusMessage"] = "Category name is required.";
                return RedirectToPage();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");

            var dto = new { CategoryName = NewCategoryName };

            var response = await client.PostAsJsonAsync("/api/Category", dto);

            if (response.IsSuccessStatusCode)
            {
                TempData["StatusMessage"] = "Category created successfully!";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return RedirectToPage("/Login/Login");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                TempData["StatusMessage"] = $"Failed to create category: {error}";
            }

            return RedirectToPage();
        }
        [BindProperty]
        public UpdateCategoryDto EditCategory { get; set; } = new();

        public async Task<IActionResult> OnPostEditAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.PutAsJsonAsync($"/api/Category/{EditCategory.Id}", EditCategory);

            if (!response.IsSuccessStatusCode)
            {
                TempData["StatusMessage"] = "Failed to update category.";
            }

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.DeleteAsync($"/api/Category/{id}");

            if (!response.IsSuccessStatusCode)
            {
                TempData["StatusMessage"] = "Failed to delete category.";
            }

            return RedirectToPage();
        }
    }
}
