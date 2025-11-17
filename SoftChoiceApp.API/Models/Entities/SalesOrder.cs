using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class SalesOrder
{
    public int Id { get; set; }

    public string SalesOrder1 { get; set; } = null!;

    public int CustomerId { get; set; }

    public DateOnly SalesDate { get; set; }

    public string Note { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public decimal? Discount { get; set; }

    public bool Invoicing { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<InvoicingDetail> InvoicingDetails { get; set; } = new List<InvoicingDetail>();

    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
}
