using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WeaponAccountingProject.Models;

namespace WeaponAccountingProject.Data;

public partial class WeaponAccountingContext : DbContext
{
    public WeaponAccountingContext()
    {
    }

    public WeaponAccountingContext(DbContextOptions<WeaponAccountingContext> options)
    : base(options)
    {
    }

    public virtual DbSet<CompletenessItem> CompletenessItems { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Soldier> Soldiers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<Weapon> Weapons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-1UD089JV; Initial Catalog=WeaponAccounting;Encrypt=False;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompletenessItem>(entity =>
        {
            entity.HasKey(e => e.CompletenessItemId).HasName("PK__Complete__E27DCAEB0A4440DB");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA49721F51310");
        });

        modelBuilder.Entity<Soldier>(entity =>
        {
            entity.HasKey(e => new { e.SoldierId, e.LocationId }).HasName("PK__Soldier__1BE933487AD1B88E");

            entity.Property(e => e.SoldierId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Location).WithMany(p => p.Soldiers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Soldier__Locatio__440B1D61");

            entity.HasOne(d => d.Unit).WithMany(p => p.Soldiers).HasConstraintName("FK__Soldier__UnitId__44FF419A");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__Unit__44F5ECB579828F72");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Warehous__E7FEA497AFD809B0");

            entity.Property(e => e.LocationId).ValueGeneratedNever();

            entity.HasOne(d => d.Location).WithOne(p => p.Warehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Warehouse__Locat__3F466844");
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.HasKey(e => e.WeaponId).HasName("PK__Weapon__541D0AF125D9407D");

            entity.HasOne(d => d.Location).WithMany(p => p.Weapons).HasConstraintName("FK__Weapon__Location__47DBAE45");

            entity.HasMany(d => d.CompletenessItems).WithMany(p => p.Weapons)
                .UsingEntity<Dictionary<string, object>>(
                    "Completeness",
                    r => r.HasOne<CompletenessItem>().WithMany()
                        .HasForeignKey("CompletenessItemId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Completen__Compl__4D94879B"),
                    l => l.HasOne<Weapon>().WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Completen__Weapo__4CA06362"),
                    j =>
                    {
                        j.HasKey("WeaponId", "CompletenessItemId").HasName("PK__Complete__FA3AD65F738CC68B");
                        j.ToTable("Completeness");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
