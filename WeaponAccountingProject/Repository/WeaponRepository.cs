using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Net;
using WeaponAccountingProject.Data;
using WeaponAccountingProject.Interfaces;
using WeaponAccountingProject.Models;

namespace WeaponAccountingProject.Repository
{
    public class WeaponRepository : IWeaponRepository
    {
        public enum WeaponSortField
        {
            Name,
            Value,
            RecordNumber,
            Year
        }
        private WeaponAccountingContext _context;
        public WeaponRepository(WeaponAccountingContext context)
        {
            _context = context;
        }
        public ICollection<Weapon> GetWeapons()
        {
            return _context.Weapons.Include(w => w.Location).ToList();
        }

        public Weapon GetWeapon(int id)
        {
            return _context.Weapons.Where(e=> e.WeaponId == id).FirstOrDefault();
        }
        public ICollection<Weapon> SortAllWeapons(WeaponSortField sortField)
        {
            switch(sortField)
            {
                case WeaponSortField.Name:
                    return _context.Weapons.Include(w => w.Location).OrderBy(w => w.Name).ToList();

                case WeaponSortField.Value:
                    return _context.Weapons.Include(w => w.Location).OrderBy(w => w.Value).ToList();

                case WeaponSortField.RecordNumber:
                    return _context.Weapons.Include(w => w.Location).OrderBy(w => w.RecordNumber).ToList();
                
                case WeaponSortField.Year:
                    return _context.Weapons.Include(w => w.Location).OrderBy(w => w.Year).ToList();
                default:
                    return GetWeapons();
            }
        }
        public bool WeaponExists(int id) 
        { 
            return _context.Weapons.Any(e=> e.WeaponId == id); 
        }
        public bool CreateWeapon(Weapon weapon) 
        { 
            _context.Add(weapon);
            
            return Save(); 
        }
        public bool UpdateWeapon(Weapon weapon) 
        { 
            _context.Update(weapon);
            return Save(); 
        }
        public bool DeleteWeapon(Weapon weapon) 
        {  
            _context.Remove(weapon);
            return Save(); 
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }
        //public ICollection<Weapon> GetWeapons(WeaponSortField field = WeaponSortField.Name, bool direction = true) //поле сортування enum
        //{
        //    //var q = _context.Weapons.AsQueryable();
        //    //switch(field)
        //    //{
        //    //    case WeaponSortField.Name:
        //    //        q = direction ? q.OrderBy(w => w.Name) : q.OrderByDescending(w => w.Name); 
        //    //        break;
        //    //}
        //    //return q.Include(w => w.Location).ToList();
        //}
    }
}
