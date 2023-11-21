using Microsoft.EntityFrameworkCore;

namespace GameSphere.Models;

public class BountyContext(DbContextOptions<BountyContext> options) : DbContext(options)
{
    public DbSet<Bounty> Bounties { get; set; }

    public void Initialize()
    {
        if (Bounties.Any())
            return; // DB has been seeded

        Bounties.Add(
            new()
            {
                Name = "Dr. Evil",
                Description = "Old man planning to take over the world!",
                Reward = 150.00m,
                Difficulty = BountyDifficulty.Average,
                Status = BountyStatus.Pending
            });

        SaveChanges();
    }
}
