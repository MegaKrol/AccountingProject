using WeaponAccountingProject.Models;

namespace WeaponAccountingProject.ViewModels
{
    public class CreateWeaponViewModel
    {
        public string Name { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string? RecordNumber { get; set; } = null!;
        public int Value { get; set; } = 0;
        public int LocationId { get; set; } 
    }
}
