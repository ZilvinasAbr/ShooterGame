using System;

namespace Shooter.Classes
{
	public class HeavyWeapon : Weapon
	{
		public HeavyWeapon()
		{
			SlowsSpeed = true;
		}

		public override void Shoot()
		{
			throw new NotImplementedException();
		}
	}
}
