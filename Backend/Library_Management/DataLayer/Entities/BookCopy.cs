using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class BookCopy : BaseEntity
{
    public string BookId { get; set; } = null!;

    public string CopyCode { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? BookshelfId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<BookReservation> BookReservations { get; set; } = new List<BookReservation>();

    public virtual Bookshelf? Bookshelf { get; set; }

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
}
