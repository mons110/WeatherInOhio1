using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class InternetShopContext : DbContext
{
    public InternetShopContext()
    {
    }

    public InternetShopContext(DbContextOptions<InternetShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<SavedAdress> SavedAdresses { get; set; }

    public virtual DbSet<Sklad> Sklads { get; set; }

    public virtual DbSet<Tovari> Tovaris { get; set; }

    public virtual DbSet<TovariList> TovariLists { get; set; }

    public virtual DbSet<User> Users { get; set; }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    {
    //        if(!optionsBuilder.IsConfigured)
    //        {
    //            optionsBuilder.UseSqlServer(@"Server = SKELETAL-COMPUT;Database = InternetShop; Trusted_Connection = True; Encrypt = False;");
    //        }
    //    }
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.GoodId }).HasName("PK__Comments__D7CB621FC22E83DA");

            entity.Property(e => e.Comment1).HasColumnName("Comment");

            entity.HasOne(d => d.Good).WithMany(p => p.Comments)
                .HasForeignKey(d => d.GoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__GoodId__300424B4");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__UserId__2F10007B");
        });

        modelBuilder.Entity<SavedAdress>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.City }).HasName("PK__SavedAdr__CD64864A75CB1880");

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.SavedAdresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SavedAdre__UserI__267ABA7A");
        });

        modelBuilder.Entity<Sklad>(entity =>
        {
            entity.HasKey(e => e.Idskalda);

            entity.ToTable("Sklad");

            entity.Property(e => e.Idskalda)
                .ValueGeneratedNever()
                .HasColumnName("IDSkalda");

            entity.HasOne(d => d.IdtovaraNavigation).WithMany(p => p.Sklads)
                .HasForeignKey(d => d.Idtovara)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sklad_Tovari");
        });

        modelBuilder.Entity<Tovari>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tovari__3214EC279FF06789");

            entity.ToTable("Tovari");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Price).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<TovariList>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.GoodId }).HasName("PK__TovariLi__D7CB621F3DEA98CA");

            entity.ToTable("TovariList");

            entity.HasOne(d => d.Good).WithMany(p => p.TovariLists)
                .HasForeignKey(d => d.GoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TovariLis__GoodI__2C3393D0");

            entity.HasOne(d => d.User).WithMany(p => p.TovariLists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TovariLis__UserI__2B3F6F97");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27B0C13CDF");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Nickname).HasMaxLength(20);
            entity.Property(e => e.Phonenumber).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
