using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Role : BaseEntity
{
    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
