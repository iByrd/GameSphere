using GameSphere.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameSphere.Controllers
{
    public class BountyController : Controller
    {
        private BountyContext _context;

        public BountyController(BountyContext context) { _context = context; }

        


        public IActionResult List()
        {
            List<Bounty> bounties = _context.Bounties.OrderBy(x => x.Name).ToList();

            var model = new BountyViewModel { Bounties = bounties };

            return View(model);
        }
    }
}
