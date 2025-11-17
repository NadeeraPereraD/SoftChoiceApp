using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string NIC { get; set; } = null!;

    public string Role { get; set; } = null!;

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateOnly CreatedDate { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateOnly UpdatedDate { get; set; }
}
