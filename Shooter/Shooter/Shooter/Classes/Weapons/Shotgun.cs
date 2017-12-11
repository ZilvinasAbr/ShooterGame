using System;

namespace Shooter.Classes.Weapons
{
	public class Shotgun : HeavyWeapon
	{
		public Shotgun()
		{
		    Damage = 30;
		}

        public override void Shoot(double baseDamage)
        {
            Logger.Instance.Info($"Shotgun shoots with total damage of: {baseDamage + Damage}");
        }
    }
}
