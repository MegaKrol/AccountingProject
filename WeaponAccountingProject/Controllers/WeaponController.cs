using Microsoft.AspNetCore.Mvc;
using WeaponAccountingProject.Data;
using WeaponAccountingProject.Interfaces;

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
            return View();
        }
    }
}
