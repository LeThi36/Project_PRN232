using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class BorrowRecord : BaseEntity
{
    public string UserId { get; set; } = null!;

    public string CopyId { get; set; } = null!;

    public DateOnly BorrowDate { get; set; }

    public DateOnly DueDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string Status { get; set; } = null!;

    public decimal Fine { get; set; }

    public virtual BookCopy Copy { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
