using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class ServiceSubCategory
{
    public int Id { get; set; }

    public int ServiceCatId { get; set; }

    public string SubCategoryName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateOnly CreatedDate { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateOnly UpdatedDate { get; set; }

    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();

    public virtual ServiceCategory ServiceCat { get; set; } = null!;

    public virtual ICollection<ServiceOrderDetail> ServiceOrderDetails { get; set; } = new List<ServiceOrderDetail>();
}
