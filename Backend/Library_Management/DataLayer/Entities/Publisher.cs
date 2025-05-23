using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Publisher : BaseEntity
{
    public string PublisherName { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
