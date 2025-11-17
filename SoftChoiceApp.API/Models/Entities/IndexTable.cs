using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class IndexTable
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string? Prefix { get; set; }

    public string? Suffix { get; set; }
}
