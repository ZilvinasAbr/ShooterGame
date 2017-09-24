using Shooter.Classes;
using Shooter.PatternClasses;

namespace Shooter.Interfaces
{
	public interface IBossBuilder
	{
		BossBuilder SetHp(int hp);
		BossBuilder SetSpeed(int speed);
		BossBuilder SetWeapon(Weapon weapon);

		Boss Build();
	}
}
