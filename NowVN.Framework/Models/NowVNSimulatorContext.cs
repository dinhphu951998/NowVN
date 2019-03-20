using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace NowVN.Framework.Models
{
    public partial class NowVNSimulatorContext : DbContext
    {
        public NowVNSimulatorContext()
        {
        }

        public NowVNSimulatorContext(DbContextOptions<NowVNSimulatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

        //    modelBuilder.Entity<Cart>(entity =>
        //    {
        //        entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

        //        entity.Property(e => e.UserId)
        //            .IsRequired()
        //            .HasMaxLength(100)
        //            .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<Category>(entity =>
        //    {
        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(255);
        //    });

        //    modelBuilder.Entity<Customer>(entity =>
        //    {
        //        entity.HasIndex(e => e.Mail)
        //            .HasName("UQ__Customer__2724B2D1D4F1D012")
        //            .IsUnique();

        //        entity.HasIndex(e => e.Username)
        //            .HasName("UQ__Customer__536C85E4E19EFDD5")
        //            .IsUnique();

        //        entity.Property(e => e.Id)
        //            .HasMaxLength(100)
        //            .IsUnicode(false)
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.Address)
        //            .IsRequired()
        //            .HasMaxLength(100);

        //        entity.Property(e => e.Birthdate).HasColumnType("date");

        //        entity.Property(e => e.Fullname)
        //            .IsRequired()
        //            .HasMaxLength(100);

        //        entity.Property(e => e.Gender)
        //            .HasMaxLength(20)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Mail)
        //            .IsRequired()
        //            .HasMaxLength(100)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Password)
        //            .IsRequired()
        //            .HasMaxLength(100)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Phone)
        //            .IsRequired()
        //            .HasMaxLength(20)
        //            .IsUnicode(false);

        //        entity.Property(e => e.StartDate)
        //            .HasColumnType("date")
        //            .HasDefaultValueSql("(getdate())");

        //        entity.Property(e => e.Username)
        //            .IsRequired()
        //            .HasMaxLength(100)
        //            .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        entity.HasIndex(e => e.Mail)
        //            .HasName("UQ__Employee__2724B2D190551D05")
        //            .IsUnique();

        //        entity.HasIndex(e => e.Phone)
        //            .HasName("UQ__Employee__5C7E359E42F2DDC5")
        //            .IsUnique();

        //        entity.HasIndex(e => e.Username)
        //            .HasName("UQ__Employee__536C85E4BE3C1EF5")
        //            .IsUnique();

        //        entity.Property(e => e.Id)
        //            .HasMaxLength(100)
        //            .IsUnicode(false)
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.Address)
        //            .IsRequired()
        //            .HasMaxLength(100);

        //        entity.Property(e => e.Birthdate).HasColumnType("date");

        //        entity.Property(e => e.EndDate).HasColumnType("date");

        //        entity.Property(e => e.Fullname)
        //            .IsRequired()
        //            .HasMaxLength(100);

        //        entity.Property(e => e.Gender)
        //            .HasMaxLength(20)
        //            .IsUnicode(false)
        //            .HasDefaultValueSql("('Other')");

        //        entity.Property(e => e.Mail)
        //            .IsRequired()
        //            .HasMaxLength(100)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Password)
        //            .IsRequired()
        //            .HasMaxLength(100)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Phone)
        //            .IsRequired()
        //            .HasMaxLength(20)
        //            .IsUnicode(false);

        //        entity.Property(e => e.RoleId).HasColumnName("RoleID");

        //        entity.Property(e => e.StartDate)
        //            .HasColumnType("date")
        //            .HasDefaultValueSql("(getdate())");

        //        entity.Property(e => e.Username)
        //            .IsRequired()
        //            .HasMaxLength(100)
        //            .IsUnicode(false);

        //        entity.HasOne(d => d.Role)
        //            .WithMany(p => p.Employee)
        //            .HasForeignKey(d => d.RoleId)
        //            .HasConstraintName("FK__Employee__RoleID__1B0907CE");
        //    });

        //    modelBuilder.Entity<Image>(entity =>
        //    {
        //        entity.Property(e => e.Path)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.HasOne(d => d.Product)
        //            .WithMany(p => p.Image)
        //            .HasForeignKey(d => d.ProductId)
        //            .HasConstraintName("FK__Image__ProductId__37A5467C");
        //    });

        //    modelBuilder.Entity<Order>(entity =>
        //    {
        //        entity.Property(e => e.Address)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.CreatedTime)
        //            .HasColumnType("date")
        //            .HasDefaultValueSql("(getdate())");

        //        entity.Property(e => e.CustomerId)
        //            .HasColumnName("CustomerID")
        //            .HasMaxLength(100)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Fullname)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.IsAvailable)
        //            .IsRequired()
        //            .HasColumnName("isAvailable")
        //            .HasDefaultValueSql("((1))");

        //        entity.Property(e => e.Phone)
        //            .IsRequired()
        //            .HasMaxLength(255)
        //            .IsUnicode(false);

        //        entity.HasOne(d => d.Customer)
        //            .WithMany(p => p.Order)
        //            .HasForeignKey(d => d.CustomerId)
        //            .HasConstraintName("FK__Order__CustomerI__276EDEB3");
        //    });

        //    modelBuilder.Entity<OrderDetails>(entity =>
        //    {
        //        entity.Property(e => e.OrderId).HasColumnName("OrderID");

        //        entity.Property(e => e.ProductId).HasColumnName("ProductID");

        //        entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

        //        entity.HasOne(d => d.Order)
        //            .WithMany(p => p.OrderDetails)
        //            .HasForeignKey(d => d.OrderId)
        //            .HasConstraintName("FK__OrderDeta__Order__2F10007B");

        //        entity.HasOne(d => d.Product)
        //            .WithMany(p => p.OrderDetails)
        //            .HasForeignKey(d => d.ProductId)
        //            .HasConstraintName("FK__OrderDeta__Produ__300424B4");
        //    });

        //    modelBuilder.Entity<Product>(entity =>
        //    {
        //        entity.Property(e => e.CreatedTime)
        //            .HasColumnType("date")
        //            .HasDefaultValueSql("(getdate())");

        //        entity.Property(e => e.Description)
        //            .IsRequired()
        //            .HasMaxLength(200)
        //            .IsUnicode(false);

        //        entity.Property(e => e.IsActive)
        //            .IsRequired()
        //            .HasColumnName("isActive")
        //            .HasDefaultValueSql("((1))");

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(100)
        //            .IsUnicode(false);

        //        entity.HasOne(d => d.Category)
        //            .WithMany(p => p.Product)
        //            .HasForeignKey(d => d.CategoryId)
        //            .HasConstraintName("FK__Product__Categor__2A4B4B5E");
        //    });

        //    modelBuilder.Entity<Role>(entity =>
        //    {
        //        entity.HasIndex(e => e.RoleName)
        //            .HasName("UQ__Role__8A2B616083526D3E")
        //            .IsUnique();

        //        entity.Property(e => e.RoleName)
        //            .IsRequired()
        //            .HasMaxLength(100)
        //            .IsUnicode(false);
        //    });
        //}
    }
}
