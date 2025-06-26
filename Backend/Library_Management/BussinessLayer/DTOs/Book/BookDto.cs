using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.Book
{
    public class BookDto
    {
        public string Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public short? PublicationYear { get; set; }
        public string? Status { get; set; }
        public string? ImageUrl { get; set; }

        // Thông tin Author
        public string? AuthorId { get; set; }
        public string? AuthorName { get; set; }

        // Thông tin Category
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }

        // Thông tin Publisher
        public string? PublisherId { get; set; }
        public string? PublisherName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
