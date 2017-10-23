using System;

namespace Shooter.Classes
{
	public class Pistol : Weapon
	{
		public Pistol() : base("Pistol")
		{

		}

		public override void Shoot()
		{
		    Logger.Instance.Info("Pistol shoots");
		}
	}
}
