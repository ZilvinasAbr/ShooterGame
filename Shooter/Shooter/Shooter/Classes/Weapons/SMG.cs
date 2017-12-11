namespace Shooter.Classes.Weapons
{
	public class SMG : LightWeapon
	{
	    public SMG()
	    {
	        Damage = 8;
	    }

	    public override void Shoot(double baseDamage)
		{
			Logger.Instance.Info($"SMG shoots with total damage of: {baseDamage + Damage}");
		}
	}
}
