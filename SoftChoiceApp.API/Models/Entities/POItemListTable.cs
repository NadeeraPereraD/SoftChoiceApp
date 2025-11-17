using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class POItemListTable
{
    public int Id { get; set; }

    public int POId { get; set; }

    public int ItemCodeId { get; set; }

    public decimal Qty { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalUnitPrice { get; set; }

    public virtual ItemCode ItemCode { get; set; } = null!;

    public virtual PO PO { get; set; } = null!;
}
