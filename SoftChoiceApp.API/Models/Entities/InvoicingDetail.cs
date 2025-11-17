using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class InvoicingDetail
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int? ServiceOrderId { get; set; }

    public int? SalesOrderId { get; set; }

    public int ItemCodeId { get; set; }

    public decimal Qty { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Expenses { get; set; }

    public virtual Invoicing Invoice { get; set; } = null!;

    public virtual ItemCode ItemCode { get; set; } = null!;

    public virtual SalesOrder? SalesOrder { get; set; }

    public virtual ServiceOrder? ServiceOrder { get; set; }
}
