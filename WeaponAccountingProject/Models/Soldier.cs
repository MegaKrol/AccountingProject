using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeaponAccountingProject.Models;

[PrimaryKey("SoldierId", "LocationId")]
[Table("Soldier")]
public partial class Soldier
{
    [Key]
    public int SoldierId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Post { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string Rank { get; set; } = null!;

    [Key]
    public int LocationId { get; set; }

    public int? UnitId { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("Soldiers")]
    public virtual Location Location { get; set; } = null!;

    [ForeignKey("UnitId")]
    [InverseProperty("Soldiers")]
    public virtual Unit? Unit { get; set; }
}
