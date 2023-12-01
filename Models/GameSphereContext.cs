using Microsoft.EntityFrameworkCore;

namespace GameSphere.Models;

public class GameSphereContext(DbContextOptions<GameSphereContext> options) : DbContext(options)
{
    public DbSet<Bounty> Bounties { get; set; }
    public DbSet<Weapon> Weapons { get; set; }

    public void Initialize()
    {
        if (!Bounties.Any())
        {
            Bounties.Add(
                new()
                {
                    Name = "Dr. Evil",
                    Description = "Old man planning to take over the world!",
                    Reward = 150.00m,
                    Difficulty = DifficultyType.Average,
                    Status = StatusType.Pending
                });
        }


        if (!Weapons.Any())
        {
            Weapons.AddRange(
                new()
                {
                    Name = "Longsword",
                    Damage = 10,
                    Weight = 3.0m,
                    Cost = 50.00m
                },
                new()
                {
                    Name = "Spear",
                    Damage = 15,
                    Weight = 3.5m,
                    Cost = 100.00m
                },
                new()
                {
                    Name = "Battle Axe",
                    Damage = 20,
                    Weight = 6.0m,
                    Cost = 150.00m
                });
        }

        SaveChanges();
    }
}
