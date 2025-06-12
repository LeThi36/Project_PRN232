using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class User : BaseEntity
{
    public string Username { get; set; } = null!;
    public string StudentCode { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public int? Gender { get; set; }

    public string? Address { get; set; }

    public string? RoleId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<BookFavorite> BookFavorites { get; set; } = new List<BookFavorite>();

    public virtual ICollection<BookReservation> BookReservations { get; set; } = new List<BookReservation>();

    public virtual ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();

    public virtual Role? Role { get; set; }
}
