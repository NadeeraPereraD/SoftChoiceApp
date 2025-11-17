using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class Invoicing
{
    public int Id { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public int CustomerId { get; set; }

    public string Description { get; set; } = null!;

    public bool Type { get; set; }

    public decimal TotalPrice { get; set; }

    public bool IsPost { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<InvoicingDetail> InvoicingDetails { get; set; } = new List<InvoicingDetail>();
}
