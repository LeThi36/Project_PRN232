using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Category : BaseEntity
{
    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
