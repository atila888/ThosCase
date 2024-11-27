using System;
using System.Collections.Generic;
using System.Reflection.Emit;
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
    {
        if (!optionsBuilder.IsConfigured)
        {
        }
    }

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
        });

        modelBuilder.Entity<Productproperty>(entity =>
        {
            entity.ToTable("PRODUCTPROPERTY");

            entity.Property(e => e.Productpropertyid).HasColumnName("PRODUCTPROPERTYID");
            entity.Property(e => e.Productid).HasColumnName("PRODUCTID");
            entity.Property(e => e.Propertyid).HasColumnName("PROPERTYID");
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
