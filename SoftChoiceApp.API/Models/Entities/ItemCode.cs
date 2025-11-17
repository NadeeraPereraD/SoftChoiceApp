using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class ItemCode
{
    public int Id { get; set; }

    public string ItemCode1 { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public virtual ICollection<InvoicingDetail> InvoicingDetails { get; set; } = new List<InvoicingDetail>();

    public virtual ICollection<ItemDetail> ItemDetails { get; set; } = new List<ItemDetail>();

    public virtual ICollection<POItemListTable> POItemListTables { get; set; } = new List<POItemListTable>();

    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();

    public virtual ICollection<ServiceOrderDetail> ServiceOrderDetails { get; set; } = new List<ServiceOrderDetail>();
}
