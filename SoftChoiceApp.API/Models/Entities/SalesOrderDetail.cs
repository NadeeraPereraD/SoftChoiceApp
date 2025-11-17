using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class SalesOrderDetail
{
    public int Id { get; set; }

    public int SalesOrderId { get; set; }

    public int SalesCatId { get; set; }

    public int SalesSubCatId { get; set; }

    public int? ItemCodeId { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Qty { get; set; }

    public virtual ItemCode? ItemCode { get; set; }

    public virtual ServiceCategory SalesCat { get; set; } = null!;

    public virtual SalesOrder SalesOrder { get; set; } = null!;

    public virtual ServiceSubCategory SalesSubCat { get; set; } = null!;
}
