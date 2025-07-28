using System.Net.Http.Json;
using BussinessLayer.DTOs;
using BussinessLayer.DTOs.Book;
using BussinessLayer.DTOs.BookCopy;
using BussinessLayer.DTOs.NewFolder1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.BookCopy
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty(SupportsGet = true, Name = "bookId")]
        public string BookId { get; set; }

        public string BookTitle { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterStatus { get; set; }

        [BindProperty(SupportsGet = true, Name = "page")]
        public int Page { get; set; } = 1;

        public int TotalPages { get; set; }

        public int PageSize { get; set; } = 5;

        public List<BookCopyResponseDto> BookCopies { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Console.WriteLine($"DEBUG >>> BookId = {BookId}, SearchId = {SearchId}, FilterStatus = {FilterStatus}, Page = {Page}");

            if (string.IsNullOrEmpty(BookId))
            {
                TempData["StatusMessage"] = "Book ID is missing.";
                return RedirectToPage("/Book/Index");
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            var query = $"/api/BookCopies/paged?bookId={BookId}&search={SearchId}&status={FilterStatus}&page={Page}&pageSize={PageSize}";

            Console.WriteLine("DEBUG >>> API Query: " + query);

            var paginationResponse = await client.GetFromJsonAsync<PaginationResult<BookCopyResponseDto>>(query);

            if (paginationResponse != null)
            {
                BookCopies = paginationResponse.Items.ToList();
                TotalPages = paginationResponse.TotalPages;
                Console.WriteLine($"DEBUG >>> Received {BookCopies.Count} items.");
            }
            else
            {
                Console.WriteLine("DEBUG >>> API returned null.");
            }

            var bookResponse = await client.GetFromJsonAsync<BookDto>($"/api/Books/{BookId}");
            BookTitle = bookResponse?.Title ?? "(Unknown Book)";

            return Page();
        }

        public async Task<IActionResult> OnPostEditAsync(string Id, string Status, string BookId)
        {
            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(Status))
            {
                TempData["StatusMessage"] = "Invalid data.";
                return RedirectToPage(new { BookId });
            }

            try
            {
                var client = _httpClientFactory.CreateClient("ApiClient");
                var dto = new BookCopyUpdateDto { Status = Status };
                var response = await client.PutAsJsonAsync($"/api/BookCopies/{Id}", dto);

                if (response.IsSuccessStatusCode)
                {
                    TempData["StatusMessage"] = "Book copy updated successfully.";
                }
                else
                {
                    TempData["StatusMessage"] = $"Update failed: {await response.Content.ReadAsStringAsync()}";
                }
            }
            catch (Exception ex)
            {
                TempData["StatusMessage"] = $"Update error: {ex.Message}";
            }

            return RedirectToPage("/BookCopy/Index", new { bookId = BookId, page = Page, searchId = SearchId, filterStatus = FilterStatus });


        }

        public async Task<IActionResult> OnPostDeleteAsync(string Id, string BookId)
        {
            if (string.IsNullOrEmpty(Id))
            {
                TempData["StatusMessage"] = "BookCopy ID is required.";
                return RedirectToPage(new { BookId });
            }

            try
            {
                var client = _httpClientFactory.CreateClient("ApiClient");
                var response = await client.DeleteAsync($"/api/BookCopies/{Id}");

                if (response.IsSuccessStatusCode)
                {
                    TempData["StatusMessage"] = "Book copy deleted successfully.";
                }
                else
                {
                    TempData["StatusMessage"] = $"Delete failed: {await response.Content.ReadAsStringAsync()}";
                }
            }
            catch (Exception ex)
            {
                TempData["StatusMessage"] = $"Delete error: {ex.Message}";
            }

            return RedirectToPage("/BookCopy/Index", new { bookId = BookId, page = Page, searchId = SearchId, filterStatus = FilterStatus });


        }

        public async Task<IActionResult> OnPostCreateCopiesAsync(string BookId, int NumberOfCopies, string Status)
        {
            if (string.IsNullOrEmpty(BookId) || NumberOfCopies < 1 || string.IsNullOrEmpty(Status))
            {
                TempData["StatusMessage"] = "Invalid input.";
                return RedirectToPage(new { BookId });
            }

            try
            {
                var client = _httpClientFactory.CreateClient("ApiClient");

                for (int i = 0; i < NumberOfCopies; i++)
                {
                    var createDto = new BookCopyCreateDto
                    {
                        BookId = BookId,
                        Status = Status
                    };

                    var response = await client.PostAsJsonAsync("/api/BookCopies", createDto);
                    if (!response.IsSuccessStatusCode)
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        TempData["StatusMessage"] = $"Failed to create one or more copies: {error}";
                        return RedirectToPage(new { BookId });
                    }
                }

                TempData["StatusMessage"] = $"Successfully created {NumberOfCopies} book copies.";
            }
            catch (Exception ex)
            {
                TempData["StatusMessage"] = $"Error: {ex.Message}";
            }

            return RedirectToPage("/BookCopy/Index", new { bookId = BookId, page = Page, searchId = SearchId, filterStatus = FilterStatus });


        }
    }
}
