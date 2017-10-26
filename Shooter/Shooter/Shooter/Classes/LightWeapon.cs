using System;

namespace Shooter.Classes
{
	public class LightWeapon : Weapon
	{
		public LightWeapon()
		{
			SlowsSpeed = false;
		}

		public override void Shoot()
		{
			throw new NotImplementedException();
		}
	}
}
