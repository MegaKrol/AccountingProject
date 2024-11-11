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

    public virtual DbSet<Weapon> Weapons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompletenessItem>(entity =>
        {
            entity.HasKey(e => e.CompletenessItemId).HasName("PK__Complete__E27DCAEB0A4440DB");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA497D37E3B7E");
        });

        modelBuilder.Entity<Soldier>(entity =>
        {
            entity.HasKey(e => e.SoldierId).HasName("PK__Soldier__7596D901DF73424B");

            entity.HasOne(d => d.Location).WithMany(p => p.Soldiers).HasConstraintName("FK__Soldier__Locatio__693CA210");
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.HasKey(e => e.WeaponId).HasName("PK__Weapon__541D0AF125D9407D");

            entity.HasOne(d => d.Location).WithMany(p => p.Weapons).HasConstraintName("FK__Weapon__Location__6B24EA82");

            entity.HasOne(d => d.Soldier).WithMany(p => p.Weapons).HasConstraintName("FK__Weapon__SoldierI__6A30C649");

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
