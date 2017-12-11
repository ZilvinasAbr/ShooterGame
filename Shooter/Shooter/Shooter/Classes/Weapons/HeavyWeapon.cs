namespace Shooter.Classes.Weapons
{
	public abstract class HeavyWeapon : Weapon
	{
		protected HeavyWeapon()
		{
			SlowsSpeed = true;
		    Damage = 10;
		}
	}
}
