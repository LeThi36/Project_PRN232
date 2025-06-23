using System;
using System.ComponentModel.DataAnnotations;

namespace BussinessLayer.DTOs.Book
{
    public class BookFilterAndSearchRequestDto
    {
        public string? SearchTerm { get; set; } // Search by title/author/descrip...
        public string? CategoryId { get; set; }
        public string? AuthorId { get; set; }
        public string? PublisherId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Page number must be at least 1.")]
        public int PageNumber { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
        public int PageSize { get; set; } = 10;

        public bool IncludeDeleted { get; set; } = false; // Mặc định không bao gồm sách đã xóa mềm
    }
}