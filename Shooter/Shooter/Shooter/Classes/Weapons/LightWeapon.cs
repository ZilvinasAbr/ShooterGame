namespace Shooter.Classes.Weapons
{
	public abstract class LightWeapon : Weapon
	{
		protected LightWeapon()
		{
			SlowsSpeed = false;
		    Damage = 12;
		}
	}
}
