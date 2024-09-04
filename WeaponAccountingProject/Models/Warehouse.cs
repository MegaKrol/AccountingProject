using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeaponAccountingProject.Models;

[Table("Warehouse")]
public partial class Warehouse
{
    [Key]
    public int LocationId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [ForeignKey("LocationId")]
    [InverseProperty("Warehouse")]
    public virtual Location Location { get; set; } = null!;
}
