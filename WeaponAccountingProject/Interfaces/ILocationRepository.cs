using WeaponAccountingProject.Models;

namespace WeaponAccountingProject.Interfaces
{
    public interface ILocationRepository
    {
        ICollection<Location> GetLocations();
    }
}
