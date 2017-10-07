using Shooter.Classes;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
	class ShotgunFactory : IWeaponFactory
	{
		public IWeapon CreateWeapon()
		{
			return new Shotgun();
		}
	}
}
