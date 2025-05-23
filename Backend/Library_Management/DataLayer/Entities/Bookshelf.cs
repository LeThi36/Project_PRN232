using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Bookshelf : BaseEntity
{
    public string Rack { get; set; } = null!;

    public int ShelfNumber { get; set; }

    public int Capacity { get; set; }

    public int CurrentCount { get; set; }

    public virtual ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
}
