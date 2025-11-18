using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoftChoiceApp.API.Models.Entities;

namespace SoftChoiceApp.API.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<GRN> GRNs { get; set; }

    public virtual DbSet<IndexTable> IndexTables { get; set; }

    public virtual DbSet<Invoicing> Invoicings { get; set; }

    public virtual DbSet<InvoicingDetail> InvoicingDetails { get; set; }

    public virtual DbSet<ItemCode> ItemCodes { get; set; }

    public virtual DbSet<ItemDetail> ItemDetails { get; set; }

    public virtual DbSet<PO> POs { get; set; }

    public virtual DbSet<POItemListTable> POItemListTables { get; set; }

    public virtual DbSet<SalesOrder> SalesOrders { get; set; }

    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

    public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

    public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }

    public virtual DbSet<ServiceOrderDetail> ServiceOrderDetails { get; set; }

    public virtual DbSet<ServiceSubCategory> ServiceSubCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserRoleMapping> UserRoleMappings { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0721BF7517");

            entity.ToTable("Customer");

            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Line1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Line2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Tel1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tel2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GRN>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GRN__3214EC07F7D33EC5");

            entity.ToTable("GRN");

            entity.HasIndex(e => e.TotalPrice, "UQ__GRN__8EFFDA8B0050E9DC").IsUnique();

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.GRNNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.PO).WithMany(p => p.GRNs)
                .HasForeignKey(d => d.POId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRN_PO");

            entity.HasOne(d => d.Vendor).WithMany(p => p.GRNs)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRN_Vendor");
        });

        modelBuilder.Entity<IndexTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IndexTab__3214EC07E0C3F2A6");

            entity.ToTable("IndexTable");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prefix)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Suffix)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Invoicing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoicin__3214EC071BAEC019");

            entity.ToTable("Invoicing");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoicings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoicing_Customer");
        });

        modelBuilder.Entity<InvoicingDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoicin__3214EC07A83EA076");

            entity.Property(e => e.Expenses).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Qty).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoicingDetails)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoicingDetails_Invoice");

            entity.HasOne(d => d.ItemCode).WithMany(p => p.InvoicingDetails)
                .HasForeignKey(d => d.ItemCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoicingDetails_ItemCode");

            entity.HasOne(d => d.SalesOrder).WithMany(p => p.InvoicingDetails)
                .HasForeignKey(d => d.SalesOrderId)
                .HasConstraintName("FK_InvoicingDetails_SalesOrder");

            entity.HasOne(d => d.ServiceOrder).WithMany(p => p.InvoicingDetails)
                .HasForeignKey(d => d.ServiceOrderId)
                .HasConstraintName("FK_InvoicingDetails_ServiceOrder");
        });

        modelBuilder.Entity<ItemCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemCode__3214EC0724CCE21F");

            entity.ToTable("ItemCode");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ItemCode1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ItemCode");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemDeta__3214EC07DC5BC085");

            entity.Property(e => e.InStock).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Qty).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.GRN).WithMany(p => p.ItemDetails)
                .HasForeignKey(d => d.GRNId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemDetails_GRN");

            entity.HasOne(d => d.ItemCode).WithMany(p => p.ItemDetails)
                .HasForeignKey(d => d.ItemCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemDetails_ItemCode");
        });

        modelBuilder.Entity<PO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PO__3214EC0776FB2B28");

            entity.ToTable("PO");

            entity.HasIndex(e => e.TotalPrice, "UQ__PO__8EFFDA8BDD4478FF").IsUnique();

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PONo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Vendor).WithMany(p => p.POs)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PO_Vendor");
        });

        modelBuilder.Entity<POItemListTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__POItemLi__3214EC07AA226D0D");

            entity.ToTable("POItemListTable");

            entity.Property(e => e.Qty).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalUnitPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ItemCode).WithMany(p => p.POItemListTables)
                .HasForeignKey(d => d.ItemCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_POItemList_Item");

            entity.HasOne(d => d.PO).WithMany(p => p.POItemListTables)
                .HasForeignKey(d => d.POId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_POItemList_PO");
        });

        modelBuilder.Entity<SalesOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SalesOrd__3214EC07DD75AA9B");

            entity.ToTable("SalesOrder");

            entity.HasIndex(e => e.Note, "UQ__SalesOrd__7D8C2ADD30DE517A").IsUnique();

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Discount).HasColumnType("decimal(2, 2)");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SalesOrder1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SalesOrder");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrder_Customer");
        });

        modelBuilder.Entity<SalesOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SalesOrd__3214EC07AB3D4800");

            entity.Property(e => e.Qty).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ItemCode).WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.ItemCodeId)
                .HasConstraintName("FK_SalesOrderDetails_ItemCode");

            entity.HasOne(d => d.SalesCat).WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.SalesCatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderDetails_SalesCategory");

            entity.HasOne(d => d.SalesOrder).WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.SalesOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderDetails_SalesOrder");

            entity.HasOne(d => d.SalesSubCat).WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.SalesSubCatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderDetails_SalesSubCategory");
        });

        modelBuilder.Entity<ServiceCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceC__3214EC07825493E2");

            entity.ToTable("ServiceCategory");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ServiceCategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ServiceOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceO__3214EC070566F856");

            entity.ToTable("ServiceOrder");

            entity.HasIndex(e => e.Note, "UQ__ServiceO__7D8C2ADDB5562501").IsUnique();

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Discount).HasColumnType("decimal(2, 2)");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ServiceOrder1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ServiceOrder");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ServiceOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceO__3214EC073894F83F");

            entity.Property(e => e.Qty).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ItemCode).WithMany(p => p.ServiceOrderDetails)
                .HasForeignKey(d => d.ItemCodeId)
                .HasConstraintName("FK_ServiceOrderDetails_ItemCode");

            entity.HasOne(d => d.ServiceCat).WithMany(p => p.ServiceOrderDetails)
                .HasForeignKey(d => d.ServiceCatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceOrderDetails_ServiceCategory");

            entity.HasOne(d => d.ServiceOrder).WithMany(p => p.ServiceOrderDetails)
                .HasForeignKey(d => d.ServiceOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceOrderDetails_ServiceOrder");

            entity.HasOne(d => d.ServiceSubCat).WithMany(p => p.ServiceOrderDetails)
                .HasForeignKey(d => d.ServiceSubCatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceOrderDetails_ServiceSubCategory");
        });

        modelBuilder.Entity<ServiceSubCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceS__3214EC0758726759");

            entity.ToTable("ServiceSubCategory");

            entity.HasIndex(e => e.Description, "UQ__ServiceS__4EBBBAC9161C88B8").IsUnique();

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SubCategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ServiceCat).WithMany(p => p.ServiceSubCategories)
                .HasForeignKey(d => d.ServiceCatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceSubCategory_ServiceCategory");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC079BA75EEC");

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456868FAC5A").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NIC)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07C3D894C8");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserRoleMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC073B30814A");

            entity.ToTable("UserRoleMapping");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoleMappings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRoleM__UserI__160F4887");

            entity.HasOne(d => d.UserRole).WithMany(p => p.UserRoleMappings)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRoleM__UserR__17036CC0");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vendor__3214EC0796A07A64");

            entity.ToTable("Vendor");

            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Line1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Line2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Tel1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tel2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VendorCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VendorName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
