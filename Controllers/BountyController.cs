
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameSphere.Models;

namespace GameSphere.Controllers
{
    public class BountyController : Controller
    {
        private BountyContext context;

        public BountyController(BountyContext ctx) => context = ctx; 

        


        public IActionResult List()
        {
            BountyViewModel bountyViewModel = new BountyViewModel();

            bountyViewModel.Difficulties = context.Difficulties.ToList();
            bountyViewModel.Statuses = context.Statuses.ToList();

            IQueryable<Bounty> query = context.Bounties
                .Include(x => x.Difficulty).Include(x => x.Status);

            bountyViewModel.Bounties = query.OrderBy(x => x.Id).ToList();

            return View(bountyViewModel);
        }

        public IActionResult Add()
        {
            BountyViewModel bountyViewModel = new BountyViewModel();
            bountyViewModel.Difficulties = context.Difficulties.ToList();
            bountyViewModel.Statuses = context.Statuses.ToList();
            return View(bountyViewModel);
        }

        [HttpPost]
        public IActionResult Add(BountyViewModel model)
        {
            if (ModelState.IsValid)
            {
                context.Bounties.Add(model.NewBounty);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                model.Difficulties = context.Difficulties.ToList();
                model.Statuses = context.Statuses.ToList();
                return View(model);
            }
        }
    }
}
