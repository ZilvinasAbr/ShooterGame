using Shooter.Classes;
using Shooter.Classes.Weapons;
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
					return new Bazooka
					{
						Name = "Bazooka"
					};
				case WeaponName.Shotgun:
					return new Shotgun
					{
						Name = "Shotgun"
					};
				default:
					return null;
			}
		}
	}
}
