using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class ItemDetail
{
    public int Id { get; set; }

    public int ItemCodeId { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal SellingPrice { get; set; }

    public int GRNId { get; set; }

    public decimal Qty { get; set; }

    public decimal InStock { get; set; }

    public virtual GRN GRN { get; set; } = null!;

    public virtual ItemCode ItemCode { get; set; } = null!;
}
