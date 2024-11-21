using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ThosCase.Data.Models.Context;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productproperty> Productproperties { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=stigman;User Id=stigman;Password=Stig_Man_1;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("CATEGORY");

            entity.Property(e => e.Categoryid).HasColumnName("CATEGORYID");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CATEGORYNAME");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Creatoruserid).HasColumnName("CREATORUSERID");
            entity.Property(e => e.Isdeleted).HasColumnName("ISDELETED");
            entity.Property(e => e.Parentcategoryid).HasColumnName("PARENTCATEGORYID");

            entity.HasOne(d => d.Creatoruser).WithMany(p => p.Categories)
                .HasForeignKey(d => d.Creatoruserid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CATEGORY__CREATO__37A5467C");

            entity.HasOne(d => d.Parentcategory).WithMany(p => p.InverseParentcategory)
                .HasForeignKey(d => d.Parentcategoryid)
                .HasConstraintName("FK__CATEGORY__PARENT__33D4B598");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("PRODUCT");

            entity.Property(e => e.Productid).HasColumnName("PRODUCTID");
            entity.Property(e => e.Categoryid).HasColumnName("CATEGORYID");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Creatoruserid).HasColumnName("CREATORUSERID");
            entity.Property(e => e.Imagepath)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("IMAGEPATH");
            entity.Property(e => e.Isdeleted).HasColumnName("ISDELETED");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("PRICE");
            entity.Property(e => e.Producname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PRODUCNAME");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("FK__PRODUCT__CATEGOR__38996AB5");

            entity.HasOne(d => d.Creatoruser).WithMany(p => p.Products)
                .HasForeignKey(d => d.Creatoruserid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCT__CREATOR__398D8EEE");
        });

        modelBuilder.Entity<Productproperty>(entity =>
        {
            entity.ToTable("PRODUCTPROPERTY");

            entity.Property(e => e.Productpropertyid).HasColumnName("PRODUCTPROPERTYID");
            entity.Property(e => e.Productid).HasColumnName("PRODUCTID");
            entity.Property(e => e.Propertyid).HasColumnName("PROPERTYID");

            entity.HasOne(d => d.Product).WithMany(p => p.Productproperties)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("FK__PRODUCTPR__PRODU__3A81B327");

            entity.HasOne(d => d.Property).WithMany(p => p.Productproperties)
                .HasForeignKey(d => d.Propertyid)
                .HasConstraintName("FK__PRODUCTPR__PROPE__3B75D760");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.ToTable("PROPERTY");

            entity.Property(e => e.Propertyid).HasColumnName("PROPERTYID");
            entity.Property(e => e.Key)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KEY_");
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VALUE");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USER_");

            entity.Property(e => e.Userid).HasColumnName("USERID");
            entity.Property(e => e.Hashpassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HASHPASSWORD");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Saltpassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SALTPASSWORD");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SURNAME");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
