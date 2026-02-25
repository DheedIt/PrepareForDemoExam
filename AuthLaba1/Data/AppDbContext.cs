using System;
using System.Collections.Generic;
using AuthLaba1.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthLaba1.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("group");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("history");

            entity.Property(e => e.Info).HasMaxLength(500);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("item");

            entity.HasIndex(e => e.UserId, "fk_Item_User1_idx");

            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Items)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Item_User1");
        });

        modelBuilder.Entity<Mark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mark");

            entity.HasIndex(e => e.ItemId, "fk_Mark_Item1_idx");

            entity.Property(e => e.ItemId).HasColumnName("Item_Id");

            entity.HasOne(d => d.Item).WithMany(p => p.Marks)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Mark_Item1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.GroupId, "fk_User_Group1_idx");

            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.Password).HasMaxLength(128);
            entity.Property(e => e.UserType).HasColumnType("enum('Teacher','Student')");
            entity.Property(e => e.Username).HasMaxLength(45);

            entity.HasOne(d => d.Group).WithMany(p => p.Users)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_Group1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
