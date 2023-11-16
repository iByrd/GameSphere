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
    }
}
