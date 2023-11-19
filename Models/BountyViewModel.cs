

namespace GameSphere.Models
{
    public class BountyViewModel
    {
        public BountyViewModel()
        {
            NewBounty = new Bounty();
        }

        public List<Bounty>? Bounties { get; set; }

        public List<Status>? Statuses { get; set; }

        public List<Difficulty>? Difficulties { get; set; }

        public Bounty NewBounty { get; set; }
    }
}
