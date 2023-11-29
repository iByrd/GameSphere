using GameSphere.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameSphere.Controllers
{
    public class WeaponController : Controller
    {
        private BountyContext context;
        public WeaponController(BountyContext ctx) => context = ctx;
        public IActionResult WeaponList()
        {
            WeaponViewModel weaponViewModel = new WeaponViewModel();

            IQueryable<Weapon> query = context.Weapons;
            weaponViewModel.Weapons = query.OrderBy(x => x.WeaponId).ToList();

            return View(weaponViewModel);
        }

        public IActionResult WeaponAdd()
        {
            WeaponViewModel weaponViewModel = new WeaponViewModel();
            return View(weaponViewModel);
        }

        [HttpPost]
        public IActionResult WeaponAdd(WeaponViewModel model)
        {
            if (ModelState.IsValid)
            {
                context.Weapons.Add(model.NewWeapon);
                context.SaveChanges();
                return RedirectToAction("WeaponList");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Delete(Weapon weapon)
        { 
            context.Weapons.Remove(weapon);
            context.SaveChanges();
            return RedirectToAction("WeaponList");
        }


    }
}
