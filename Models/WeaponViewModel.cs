namespace GameSphere.Models
{
    public class WeaponViewModel
    {
        public WeaponViewModel() 
        { 
            NewWeapon = new Weapon();
        }

        public List<Weapon>? Weapons { get; set; }

        public Weapon NewWeapon { get; set;}
    }
}
