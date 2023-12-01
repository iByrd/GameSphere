using GameSphere.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameSphere.Controllers
{
    public class WeaponController(GameSphereContext ctx) : Controller
    {
        private readonly GameSphereContext context = ctx;

        public IActionResult WeaponList() => View(context.Weapons.OrderBy(x => x.WeaponId).ToList());

        public IActionResult WeaponAdd() => View(new Weapon());

        [HttpPost]
        public IActionResult WeaponAdd(Weapon newWeapon)
        {
            if (ModelState.IsValid)
            {
                context.Weapons.Add(newWeapon);
                context.SaveChanges();
                return RedirectToAction("WeaponList");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please correct all errors");
                return View(newWeapon);
            }
        }

        [HttpPost]
        public IActionResult Delete(Weapon model)
        {
            context.Weapons.Remove(model);
            context.SaveChanges();
            return RedirectToAction("WeaponList");
        }
    }
}
