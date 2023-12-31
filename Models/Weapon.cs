﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSphere.Models
{
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }

        [Required(ErrorMessage = "Please enter the weapon's name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the weapon's damage.")]
        public int Damage { get; set; }

        [Required(ErrorMessage = "Please enter the weapon's weight.")]
        [Column(TypeName = "decimal(18,1)")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Please enter the weapon's cost.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }
    }
}
