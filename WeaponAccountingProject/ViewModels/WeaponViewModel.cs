using WeaponAccountingProject.Models;

namespace WeaponAccountingProject.ViewModels
{
    public class WeaponViewModel
    {
        public CreateWeaponViewModel CreateWeaponViewModel { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
        public Weapon Weapon { get; set; }
    }
}
