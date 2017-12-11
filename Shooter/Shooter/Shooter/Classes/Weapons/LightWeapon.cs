using System;

namespace Shooter.Classes.Weapons
{
	public class LightWeapon : Weapon
	{
		public LightWeapon()
		{
			SlowsSpeed = false;
		    Damage = 12;
		}

		public override void Shoot(double baseDamage)
		{
		    Logger.Instance.Info($"Light Weapon shoots with total damage of: {baseDamage + Damage}");
        }
	}
}
