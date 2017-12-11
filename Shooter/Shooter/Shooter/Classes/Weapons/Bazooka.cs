namespace Shooter.Classes.Weapons
{
	public class Bazooka : HeavyWeapon
	{
	    public int AmmoLeft { get; set; }

	    public Bazooka()
	    {
	        Damage = 100;
	        AmmoLeft = 1;
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
		    Logger.Instance.Info($"Bazooka shoots with total damage of: {baseDamage + Damage}");
		}
	}
}
