using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class BookCopy : BaseEntity
{
    public string BookId { get; set; } = null!;

    public string CopyCode { get; set; } = null!; // Dùng GUID 8 số thôi để tạo mã cho mỗi quyển sách

    public string Status { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<BookReservation> BookReservations { get; set; } = new List<BookReservation>();

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
}
