using System.ComponentModel.DataAnnotations.Schema;

namespace GameSphere.Models
{
    public class Bounty
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Reward { get; set; }

        public string DifficultyId { get; set; }

        public Difficulty Difficulty { get; set; }

        public string StatusId { get; set; }

        public Status Status { get; set; }
    }
}
