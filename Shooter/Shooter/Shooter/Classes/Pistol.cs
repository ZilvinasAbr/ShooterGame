using System;

namespace Shooter.Classes
{
	public class Pistol : LightWeapon
	{
		public Pistol()
		{

		}

		public override void Shoot()
		{
		    Logger.Instance.Info("Pistol shoots");
		}
	}
}
