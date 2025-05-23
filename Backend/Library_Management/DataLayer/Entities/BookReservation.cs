using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class BookReservation : BaseEntity
{
    public string UserId { get; set; } = null!;

    public string CopyId { get; set; } = null!;

    public DateOnly ReservationDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual BookCopy Copy { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
