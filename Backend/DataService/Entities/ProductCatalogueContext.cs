using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataService.Entities;

public partial class ProductCatalogueContext : DbContext
{
    public ProductCatalogueContext()
    {
    }

    public ProductCatalogueContext(DbContextOptions<ProductCatalogueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Cnu;Database=ProductCatalogue;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__23CAF1D8DA0681A1");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("categoryId");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__2D10D16ADDDB37A9");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("productId");
            entity.Property(e => e.Brand)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("categoryId");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Product__categor__2C3393D0");
        });

        modelBuilder.Entity<ProductAttribute>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("PK__ProductA__03B803F0226F8283");

            entity.Property(e => e.AttributeId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("attributeId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ProductId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("productId");
            entity.Property(e => e.Value)
                .IsUnicode(false)
                .HasColumnName("value");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ProductAt__produ__2F10007B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
