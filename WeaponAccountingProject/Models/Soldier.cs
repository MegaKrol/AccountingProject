using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeaponAccountingProject.Models;

[Table("Soldier")]
public partial class Soldier
{
    [Key]
    public int SoldierId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Post { get; set; } = null!;

    [StringLength(30)]
    public string Rank { get; set; } = null!;

    public int? LocationId { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("Soldiers")]
    public virtual Location? Location { get; set; }

    [InverseProperty("Soldier")]
    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}

[Table("Officer")]
public class Officer : Soldier
{
    public ICollection<Soldier> soldiersOnDuty { get; set; }
    public ICollection<Location> locationsOnDuty { get; set; }
}
