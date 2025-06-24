using DataLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities;

public partial class User : BaseEntity
{
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
    [RegularExpression(@"^\S+$", ErrorMessage = "Username cannot contain spaces.")]
    public string Username { get; set; } = null!;

    public string StudentCode { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\W).{8,}$",
    ErrorMessage = "Password must be at least 8 characters long, contain at least 1 uppercase letter and 1 special character.")]
    public string PasswordHash { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone number must start with 0 and be exactly 10 digits.")]
    public string? PhoneNumber { get; set; }

    [DisplayName("Date of birth")]
    public DateOnly? DateOfBirth { get; set; }

    public Gender Gender { get; set; }

    public string? Address { get; set; }

    [DisplayName("Role")]
    public string? RoleId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<BookFavorite> BookFavorites { get; set; } = new List<BookFavorite>();

    public virtual ICollection<BookReservation> BookReservations { get; set; } = new List<BookReservation>();

    public virtual ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();

    public virtual Role? Role { get; set; }
}
