using Microsoft.AspNetCore.Mvc;
using GameSphere.Models;

namespace GameSphere.Controllers;

public class BountyController(BountyContext ctx) : Controller
{
    private readonly BountyContext context = ctx;

    public IActionResult List() => View(context.Bounties.OrderBy(x => x.Id).ToList());

    public IActionResult Add() => View(new Bounty());

    [HttpDelete]
    public void Delete(int bountyId) {
        var bounty = context.Bounties.Find(bountyId);
        context.Bounties.Remove(bounty);
        context.SaveChanges();
    }

    [HttpPost]
    public IActionResult Add(Bounty newBounty)
    {
        if (!ModelState.IsValid)
            return View(newBounty);

        context.Bounties.Add(newBounty);
        context.SaveChanges();
        return RedirectToAction("List");
    }

    [HttpPost]
    public IActionResult Edit(Bounty bounty)
    {
        if (!ModelState.IsValid)
            return View(bounty);

        context.Bounties.Update(bounty);
        context.SaveChanges();
        return RedirectToAction("List");
    }
}
