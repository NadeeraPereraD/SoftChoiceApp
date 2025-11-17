using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class PO
{
    public int Id { get; set; }

    public string PONo { get; set; } = null!;

    public int VendorId { get; set; }

    public string Description { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public bool IsGRN { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public virtual ICollection<GRN> GRNs { get; set; } = new List<GRN>();

    public virtual ICollection<POItemListTable> POItemListTables { get; set; } = new List<POItemListTable>();

    public virtual Vendor Vendor { get; set; } = null!;
}
