using Shooter.Interfaces;

namespace Shooter.Classes
{
	public abstract class Weapon : IWeapon
	{
		public string Name { get; set; }
		public int Damage { get; set; }
		public decimal Price { get; set; }
		public int Range { get; set; }
		public int Magazine { get; set; }

        public abstract void Shoot();

        public Weapon Clone()
        {
            return (Weapon)this.MemberwiseClone();
        }
	}
}
