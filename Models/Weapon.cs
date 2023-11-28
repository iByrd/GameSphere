using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameSphere.Models
{
    public class Weapon
    {
        public int WeaponId;

        [Required(ErrorMessage = "Please enter the weapon's name.")]
        public string Name;

        [Required(ErrorMessage = "Please enter the weapon's damage.")]
        public int Damage;

        [Required(ErrorMessage = "Please enter the weapon's weight.")]
        [Column(TypeName = "decimal(18,1)")]
        public decimal Weight;

        [Required(ErrorMessage = "Please enter the weapon's cost.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost;
    }
}
