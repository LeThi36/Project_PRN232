using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Event : BaseEntity
{
    public string EventName { get; set; } = null!;

    public DateOnly EventDate { get; set; }

    public string? Description { get; set; }
}
