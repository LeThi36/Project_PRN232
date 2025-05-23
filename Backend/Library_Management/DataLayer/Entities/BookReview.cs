using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class BookReview : BaseEntity
{
    public string UserId { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public int Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateTime? ReviewDate { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
