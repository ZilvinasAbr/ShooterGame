namespace Shooter.Classes.Weapons
{
	public class Pistol : LightWeapon
	{
		public Pistol()
		{
		    Damage = 11;
		}

		public override void Shoot(double baseDamage)
		{
		    Logger.Instance.Info($"Pistol shoots with total damage of: {baseDamage + Damage}");
        }
	}
}
