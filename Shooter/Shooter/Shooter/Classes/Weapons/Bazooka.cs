namespace Shooter.Classes.Weapons
{
	public class Bazooka : HeavyWeapon
	{
	    public Bazooka()
	    {
	        Damage = 15;
	    }

		public override void Shoot(double baseDamage)
		{
		    Logger.Instance.Info($"Bazooka shoots with total damage of: {baseDamage + Damage}");
		}
	}
}
