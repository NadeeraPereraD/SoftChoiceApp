using System;
using System.Collections.Generic;

namespace SoftChoiceApp.API.Models.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string CustomerCode { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string Line1 { get; set; } = null!;

    public string? Line2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Tel1 { get; set; } = null!;

    public string? Tel2 { get; set; }

    public string ContactPerson { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public virtual ICollection<Invoicing> Invoicings { get; set; } = new List<Invoicing>();

    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}
