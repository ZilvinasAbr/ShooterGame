using Shooter.Classes;
using Shooter.Enums;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
	public class LightWeaponFactory : WeaponFactory
	{
		public override IWeapon CreateWeapon(WeaponName lightWeapon)
		{
			switch (lightWeapon)
			{
				case WeaponName.Pistol:
					return new Pistol();
				case WeaponName.SMG:
					return new SMG();
				default:
					return null;
			}
		}
	}
}
