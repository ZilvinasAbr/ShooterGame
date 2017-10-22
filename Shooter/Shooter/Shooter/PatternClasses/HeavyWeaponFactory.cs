using Shooter.Classes;
using Shooter.Enums;

namespace Shooter.PatternClasses
{
	public class HeavyWeaponFactory : WeaponFactory
	{
		public override Weapon CreateWeapon(WeaponName heavyWeapon)
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
