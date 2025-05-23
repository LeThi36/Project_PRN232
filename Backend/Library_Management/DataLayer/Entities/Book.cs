using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Book : BaseEntity
{
    public string Title { get; set; } = null!;

    public string? CategoryId { get; set; }

    public string? AuthorId { get; set; }

    public string? PublisherId { get; set; }

    public short? PublicationYear { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();

    public virtual ICollection<BookFavorite> BookFavorites { get; set; } = new List<BookFavorite>();

    public virtual ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();

    public virtual Category? Category { get; set; }

    public virtual Publisher? Publisher { get; set; }
}
