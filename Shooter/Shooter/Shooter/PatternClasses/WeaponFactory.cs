using Shooter.Classes;
using Shooter.Enums;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
	public class WeaponFactory
	{
		public static WeaponFactory CreateFactory(WeaponType type)
		{
			switch (type)
			{
				case WeaponType.Heavy:
					return new HeavyWeaponFactory();
				case WeaponType.Light:
					return new LightWeaponFactory();
				default:
					return null;
			}
		}

		public virtual Weapon CreateWeapon(WeaponName weapon)
		{
			return null;
		}
	}
}
