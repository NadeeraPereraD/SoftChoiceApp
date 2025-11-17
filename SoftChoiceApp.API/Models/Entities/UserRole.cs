using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class UserRole
{
    public int Id { get; set; }

    public string Role { get; set; } = null!;

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateOnly CreatedDate { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateOnly UpdatedDate { get; set; }
}
