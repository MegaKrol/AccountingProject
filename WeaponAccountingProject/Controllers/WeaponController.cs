using Microsoft.AspNetCore.Mvc;
using WeaponAccountingProject.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeaponAccountingProject.Data;
using WeaponAccountingProject.Interfaces;
using WeaponAccountingProject.Models;
using Microsoft.EntityFrameworkCore;
using static WeaponAccountingProject.Repository.WeaponRepository;

namespace WeaponAccountingProject.Controllers
{
    public class WeaponController : Controller
    {
        private readonly IWeaponRepository _weaponRepository;
        public WeaponController(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }

        public IActionResult Index(WeaponSortField sortField = WeaponSortField.Name)
        {
            var weapons = _weaponRepository.SortAllWeapons(sortField); //SortAllWeapons();

            //var result = weapons.GroupBy(w => w.Name, w => w.WeaponId, 
            //                            (key, w) => new { Names = key, WeaponCount = w.Count()})
            //                            .OrderByDescending(w => w.WeaponCount).FirstOrDefault();

            return View(weapons);
        }

        [HttpGet]
        public Weapon GetWeapon(int id)
        {
            return _weaponRepository.GetWeapon(id);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var createWeaponViewModel = new CreateWeaponViewModel();
            ViewData["Locations"] = new SelectList(_weaponRepository.GetAllLocations(), "LocationId", "Name");

            return View(createWeaponViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWeaponViewModel createWeaponVM)
        {
            if (ModelState.IsValid)
            {
                var weapon = new Weapon
                {
                    Name = createWeaponVM.Name,
                    RecordNumber = createWeaponVM.RecordNumber,
                    Year = createWeaponVM.Year,
                    LocationId = createWeaponVM.LocationId,
                    Value = createWeaponVM.Value
                };
                _weaponRepository.CreateWeapon(weapon);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var weapon = await _weaponRepository.GetWeaponAsync(id);
            if(weapon == null) return View("Error");

            //ViewData["Locations"] = new SelectList(_weaponRepository.GetAllLocations(), "LocationId", "Name");
            ViewData["Locations"] = new SelectList(await _weaponRepository.GetAllLocationsAsync(), "LocationId", "Name");

            var editWeaponViewModel = new EditWeaponViewModel
            {
                WeaponId = weapon.WeaponId,
                Name = weapon.Name,
                RecordNumber = weapon.RecordNumber,
                Year = weapon.Year,
                LocationId = weapon.LocationId,
                Value = weapon.Value
            };
            return View(editWeaponViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditWeaponViewModel editWeaponVM)
        {
            if (ModelState.IsValid)
            {
                var weapon = new Weapon
                {
                    WeaponId = editWeaponVM.WeaponId,
                    Name = editWeaponVM.Name,
                    RecordNumber = editWeaponVM.RecordNumber,
                    Year = editWeaponVM.Year,
                    LocationId = editWeaponVM.LocationId,
                    Value = editWeaponVM.Value
                };
                _weaponRepository.UpdateWeapon(weapon);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed to edit weapon");
            return RedirectToAction("Edit", editWeaponVM);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            _weaponRepository.DeleteWeapon(GetWeapon(id));

            return RedirectToAction("Index");
        }
    }
}
