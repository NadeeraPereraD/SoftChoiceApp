using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class GRN
{
    public int Id { get; set; }

    public string GRNNo { get; set; } = null!;

    public int POId { get; set; }

    public int VendorId { get; set; }

    public string Description { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public bool IsGRN { get; set; }

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateOnly CreatedDate { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateOnly UpdatedDate { get; set; }

    public virtual ICollection<ItemDetail> ItemDetails { get; set; } = new List<ItemDetail>();

    public virtual PO PO { get; set; } = null!;

    public virtual Vendor Vendor { get; set; } = null!;
}
