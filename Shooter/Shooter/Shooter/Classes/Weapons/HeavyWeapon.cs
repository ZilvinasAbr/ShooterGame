namespace Shooter.Classes.Weapons
{
	public class HeavyWeapon : Weapon
	{
		public HeavyWeapon()
		{
			SlowsSpeed = true;
		    Damage = 10;
		}

		public override void Shoot(double baseDamage)
		{
		    Logger.Instance.Info($"Heavy Weapon shoots with total damage of: {baseDamage + Damage}");
        }
	}
}
