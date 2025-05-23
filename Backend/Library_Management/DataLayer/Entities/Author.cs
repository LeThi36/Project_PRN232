using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Author : BaseEntity
{
    public string AuthorName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
