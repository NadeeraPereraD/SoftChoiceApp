using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class UserRoleMapping
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int UserRoleId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual UserRole UserRole { get; set; } = null!;
}
