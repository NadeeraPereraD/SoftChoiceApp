using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class ServiceOrder
{
    public int Id { get; set; }

    public string ServiceOrder1 { get; set; } = null!;

    public int CustomerId { get; set; }

    public DateOnly ServiceDate { get; set; }

    public string Note { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public decimal? Discount { get; set; }

    public bool Invoicing { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public virtual ICollection<InvoicingDetail> InvoicingDetails { get; set; } = new List<InvoicingDetail>();

    public virtual ICollection<ServiceOrderDetail> ServiceOrderDetails { get; set; } = new List<ServiceOrderDetail>();
}
