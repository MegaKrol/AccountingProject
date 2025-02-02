using WeaponAccountingProject.Models;
using static WeaponAccountingProject.Repository.WeaponRepository;

namespace WeaponAccountingProject.Interfaces
{
    public interface IWeaponRepository
    {
        ICollection<Weapon> GetWeapons();
        public Task<ICollection<Weapon>> GetWeaponsAsync();
        Weapon GetWeapon(int id);
        bool WeaponExists(int id);
        bool CreateWeapon(Weapon weapon);
        bool UpdateWeapon(Weapon weapon);
        bool DeleteWeapon(Weapon weapon);
        ICollection<Weapon> SortAllWeapons(WeaponSortField sortField);
        ICollection<Location> GetAllLocations();
        public Task<ICollection<Location>> GetAllLocationsAsync();
        public Task<Weapon> GetWeaponAsync(int id);
        bool Save();
    }
}
