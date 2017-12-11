namespace Shooter.Classes.Weapons
{
	public class Pistol : LightWeapon
	{
	    public int AmmoLeft { get; set; }
	    public int MagazinesLeft { get; set; }
	    public int MagazineSize { get; set; }

        public Pistol()
		{
		    Damage = 11;
		    MagazineSize = 20;
		    AmmoLeft = MagazineSize;
		    MagazinesLeft = 4;
		}

	    protected override bool IsWeaponReloadable()
	    {
	        return true;
	    }

	    protected override void Reload()
	    {
	        MagazinesLeft -= 1;
	        AmmoLeft = MagazineSize;
	    }

	    protected override bool ShouldReload()
	    {
	        return AmmoLeft == 0;
	    }

	    protected override void Shoot(double baseDamage)
	    {
	        AmmoLeft -= 1;
		    Logger.Instance.Info($"Pistol shoots with total damage of: {baseDamage + Damage}");
        }
	}
}
