using Microsoft.AspNetCore.Mvc;
using WeaponAccountingProject.Data;
using WeaponAccountingProject.Interfaces;
using WeaponAccountingProject.Models;

namespace WeaponAccountingProject.Controllers
{
    public class WeaponController : Controller
    {
        private readonly IWeaponRepository _weaponRepository;
        public WeaponController(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }

        public IActionResult Index()
        {
            var weapons = _weaponRepository.GetWeapons();
            
            return View(weapons);
        }
        [HttpGet]
        public Weapon GetWeapon(int id)
        {
            return _weaponRepository.GetWeapon(id);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Weapon weapon)
        {
            if(!ModelState.IsValid)
            {
                return View(weapon);
            }
            _weaponRepository.CreateWeapon(weapon);
            return RedirectToAction("Index");
        }
    }
}
