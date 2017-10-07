using Shooter.Classes;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
	public class BazookaFactory : IWeaponFactory
	{
		public IWeapon CreateWeapon()
		{
			return new Bazooka();
		}
	}
}
