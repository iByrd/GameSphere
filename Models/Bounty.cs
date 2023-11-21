using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSphere.Models;

public class Bounty
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter a name.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter a description.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Please enter a reward.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Reward { get; set; }

    [Required(ErrorMessage = "Please select a difficulty.")]
    public BountyDifficulty Difficulty { get; set; }

    [Required(ErrorMessage = "Please determine a status.")]
    public BountyStatus Status { get; set; }
}
