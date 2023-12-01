using GameSphere.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameSphere.Controllers;

public class BountyController(GameSphereContext ctx) : Controller
{
    private readonly GameSphereContext context = ctx;

    public IActionResult List() => View(context.Bounties.OrderBy(x => x.Id).ToList());

    public IActionResult Add() => View(new Bounty());

    [HttpDelete]
    public void Delete(int bountyId)
    {
        var bounty = context.Bounties.Find(bountyId);
        context.Bounties.Remove(bounty);
        context.SaveChanges();
    }

    [HttpPost]
    public IActionResult Add(Bounty newBounty)
    {
        if (ModelState.IsValid)
        {
            context.Bounties.Add(newBounty);
            context.SaveChanges();
            return RedirectToAction("List");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Please correct all errors");
            return View(newBounty);
        }
    }

    [HttpPut]
    public void ChangeStatus(int bountyId, StatusType newStatus)
    {
        var bounty = context.Bounties.Find(bountyId);

        bounty.Status = newStatus;

        if (ModelState.IsValid)
        {
            context.Bounties.Update(bounty);
            context.SaveChanges();
        }
    }
}
