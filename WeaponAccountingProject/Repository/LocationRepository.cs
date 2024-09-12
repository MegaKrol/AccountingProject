using WeaponAccountingProject.Interfaces;
using WeaponAccountingProject.Data;
using WeaponAccountingProject.Models;

namespace WeaponAccountingProject.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly WeaponAccountingContext _context;
        public LocationRepository(WeaponAccountingContext context) 
        {
            _context = context;
        }

        public ICollection<Location> GetLocations()
        {
            return _context.Locations.ToList();
        }
    }
}
