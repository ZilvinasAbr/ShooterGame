using Shooter.Classes;
using Shooter.Classes.Weapons;
using Shooter.Enums;

namespace Shooter.PatternClasses
{
	public class LightWeaponFactory : WeaponFactory
	{
		public override Weapon CreateWeapon(WeaponName lightWeapon)
		{
			switch (lightWeapon)
			{
				case WeaponName.Pistol:
					return new Pistol
					{
						Name = "Pistol"
					};
				case WeaponName.SMG:
					return new SMG
					{
						Name = "SMG"
					};
				default:
					return null;
			}
		}
	}
}
