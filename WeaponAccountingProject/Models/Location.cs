using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeaponAccountingProject.Models;

[Table("Location")]
public partial class Location
{
    [Key]
    public int LocationId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("Location")]
    public virtual ICollection<Soldier> Soldiers { get; set; } = new List<Soldier>();

    [InverseProperty("Location")]
    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}
