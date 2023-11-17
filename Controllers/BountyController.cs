
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameSphere.Models;

namespace GameSphere.Controllers
{
    public class BountyController : Controller
    {
        private BountyContext _context;

        public BountyController(BountyContext context) { _context = context; }

        


        public IActionResult List()
        {
            BountyViewModel bountyViewModel = new BountyViewModel();

            IQueryable<Bounty> query = _context.Bounties
                .Include(x => x.Difficulty).Include(x => x.Status);

            bountyViewModel.Bounties = query.OrderBy(x => x.Id).ToList();

            return View(bountyViewModel);
        }
    }
}
