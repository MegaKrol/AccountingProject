using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeaponAccountingProject.Models;

[Table("CompletenessItem")]
public partial class CompletenessItem
{
    [Key]
    public int CompletenessItemId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [ForeignKey("CompletenessItemId")]
    [InverseProperty("CompletenessItems")]
    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}
