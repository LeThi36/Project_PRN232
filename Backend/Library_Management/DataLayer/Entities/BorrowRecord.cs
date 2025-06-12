using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class BorrowRecord : BaseEntity
{
    public string UserId { get; set; } = null!;

    public string CopyId { get; set; } = null!;

    public DateTime BorrowDate { get; set; } // Gia hạn thêm ngày mượn thì cập nhật lại BorrowDate và DueDate

    public DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }
    public int ExtensionDateCount { get; set; } = 0;

    public string Status { get; set; } = null!;

    public decimal Fine { get; set; }

    public virtual BookCopy Copy { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
