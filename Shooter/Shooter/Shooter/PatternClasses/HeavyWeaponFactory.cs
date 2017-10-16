using Shooter.Classes;
using Shooter.Enums;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
	public class HeavyWeaponFactory : WeaponFactory
	{
		public override IWeapon CreateWeapon(WeaponName heavyWeapon)
		{
			switch (heavyWeapon)
			{
				case WeaponName.Bazooka:
					return new Bazooka();
				case WeaponName.Shotgun:
					return new Shotgun();
				default:
					return null;
			}
		}
	}
}
