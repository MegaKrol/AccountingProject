using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeaponAccountingProject.Models;

[Table("Weapon")]
public partial class Weapon
{
    [Key]
    public int WeaponId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(4)]
    [Unicode(false)]
    public string Year { get; set; } = null!;

    [StringLength(20)]
    public string RecordNumber { get; set; } = null!;

    public int? SoldierId { get; set; }

    public int? LocationId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Value { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("Weapons")]
    public virtual Location? Location { get; set; }

    [ForeignKey("SoldierId")]
    [InverseProperty("Weapons")]
    public virtual Soldier? Soldier { get; set; }

    [ForeignKey("WeaponId")]
    [InverseProperty("Weapons")]
    public virtual ICollection<CompletenessItem> CompletenessItems { get; set; } = new List<CompletenessItem>();
}
