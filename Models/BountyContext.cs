using Microsoft.EntityFrameworkCore;

namespace GameSphere.Models
{
    public class BountyContext : DbContext
    {
        public BountyContext(DbContextOptions<BountyContext> options) : base(options) { }

        public DbSet<Bounty> Bounties { get; set; }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Difficulty>().HasData(
                new Difficulty { DifficultyId = "easy", Name = "Easy" },
                new Difficulty { DifficultyId = "average", Name = "Average" },
                new Difficulty { DifficultyId = "hard", Name = "Hard" },
                new Difficulty { DifficultyId = "legendary", Name = "Legendary" }
                );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "open", Name = "Open" },
                new Status { StatusId = "pending", Name = "Pending" },
                new Status { StatusId = "closed", Name = "Completed" }
            );

            modelBuilder.Entity<Bounty>().HasData(
                new Bounty
                {
                    Id = 1,
                    Name = "Dr.Evil",
                    Description = "Old man planning to take over the world!",
                    Reward = (decimal)150.00,
                    DifficultyId = "average",
                    StatusId = "pending"
                }
                );

          
        }
    }
}
