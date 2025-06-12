using DataLayer.Enum;
using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Role : BaseEntity
{
    public RoleEnum RoleName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
