using Shooter.Classes;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
	public class PistolFactory : IWeaponFactory
	{
		public IWeapon CreateWeapon()
		{
			return new Pistol();
		}
	}
}
