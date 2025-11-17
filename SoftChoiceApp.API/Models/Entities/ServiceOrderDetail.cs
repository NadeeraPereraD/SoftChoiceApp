using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class ServiceOrderDetail
{
    public int Id { get; set; }

    public int ServiceOrderId { get; set; }

    public int ServiceCatId { get; set; }

    public int ServiceSubCatId { get; set; }

    public int? ItemCodeId { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Qty { get; set; }

    public virtual ItemCode? ItemCode { get; set; }

    public virtual ServiceCategory ServiceCat { get; set; } = null!;

    public virtual ServiceOrder ServiceOrder { get; set; } = null!;

    public virtual ServiceSubCategory ServiceSubCat { get; set; } = null!;
}
