namespace Shooter.Classes.Weapons
{
	public class Shotgun : HeavyWeapon
	{
	    public int AmmoLeft { get; set; }
	    public int MagazinesLeft { get; set; }
	    public int MagazineSize { get; set; }

        public Shotgun()
		{
		    Damage = 30;
		    MagazineSize = 1;
		    AmmoLeft = MagazineSize;
		    MagazinesLeft = 10;
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
            Logger.Instance.Info($"Shotgun shoots with total damage of: {baseDamage + Damage}");
        }
    }
}
