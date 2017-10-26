using System;

namespace Shooter.Classes
{
	public class Bazooka : HeavyWeapon
	{
		public Bazooka()
		{

		}

		public override void Shoot()
		{
            Logger.Instance.Info("Bazooka shoots");
		}
	}
}
