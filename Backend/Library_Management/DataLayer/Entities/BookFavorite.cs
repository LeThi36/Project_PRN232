using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class BookFavorite : BaseEntity
{
    public string UserId { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public DateTime? AddedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
