using Shooter.Classes;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
	public class BossBuilder : IBossBuilder
	{
		public int Hp { get; set; }
		public int Speed { get; set; }
		public Weapon Weapon { get; set; }

		public BossBuilder SetHp(int hp)
		{
			Hp = hp;
			return this;
		}

		public BossBuilder SetSpeed(int speed)
		{
			Speed = speed;
			return this;
		}

		public BossBuilder SetWeapon(Weapon weapon)
		{
			Weapon = weapon;
			return this;
		}

		public Boss Build()
		{
			return new Boss(this);
		}

	}
}
