using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.DataAccessLayer.Contexts;

public partial class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public virtual DbSet<About> Abouts { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<MainPage> MainPages { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<About>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Abouts");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Addresses");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Admins");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Blogs");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Comments");

            entity.HasIndex(e => e.BlogId, "IX_BlogID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BlogId).HasColumnName("BlogID");

            entity.HasOne(d => d.Blog).WithMany(p => p.Comments)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK_dbo.Comments_dbo.Blogs_BlogID");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Contacts");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<MainPage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.MainPages");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
