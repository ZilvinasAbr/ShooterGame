namespace Shooter.Classes.Weapons
{
	public class SMG : LightWeapon
	{
	    public int AmmoLeft { get; set; }

        public SMG()
	    {
	        Damage = 8;
	        AmmoLeft = 100;
        }

	    protected override bool IsWeaponReloadable()
	    {
	        return false;
	    }

	    protected override void Reload()
	    {
	    }

	    protected override bool ShouldReload()
	    {
	        return false;
	    }

	    protected override void Shoot(double baseDamage)
	    {
	        AmmoLeft -= 1;
			Logger.Instance.Info($"SMG shoots with total damage of: {baseDamage + Damage}");
		}
	}
}
