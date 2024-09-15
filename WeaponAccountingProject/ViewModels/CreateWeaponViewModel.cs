using WeaponAccountingProject.Models;

namespace WeaponAccountingProject.ViewModels
{
    public class CreateWeaponViewModel
    {
        public string Name { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string? RecordNumber { get; set; } = null!;
        public int LocationId { get; set; } 
    }
}
