using WeaponAccountingProject.Models;

namespace WeaponAccountingProject.Interfaces
{
    public interface IWeaponRepository
    {
        ICollection<Weapon> GetWeapons();
        Weapon GetWeapon(int id);
        bool WeaponExists(int id);
        bool CreateWeapon(Weapon weapon);
        bool UpdateWeapon(Weapon weapon);
        bool DeleteWeapon(Weapon weapon);
        ICollection<Location> GetAllLocations();
        bool Save();
    }
}
