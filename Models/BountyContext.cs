using Microsoft.EntityFrameworkCore;

namespace GameSphere.Models
{
    public class BountyContext : DbContext
    {
        public BountyContext(DbContextOptions<BountyContext> options) : base(options) { }

        public DbSet<Bounty> Bounties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bounty>().HasData(
                new Bounty
                {
                    Id = 1,
                    Name = "Dr.Evil",
                    Description = "Old man planning to take over the world!",
                    Reward = (decimal)150.00
                }
                );
        }
    }
}
