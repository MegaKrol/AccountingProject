using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeaponAccountingProject.Models;

[Table("Unit")]
public partial class Unit
{
    [Key]
    public int UnitId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Unit")]
    public virtual ICollection<Soldier> Soldiers { get; set; } = new List<Soldier>();
}
