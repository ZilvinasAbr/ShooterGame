using Shooter.Interfaces;
using Shooter.PatternClasses;

namespace Shooter.Classes
{
	public class Boss : IBoss
	{
		private readonly EnemyToBossAdapter adapter;
		public int HP { get; set; }
		public int Speed { get; set; }
		public Weapon Weapon { get; set; }
		

		public Boss(BossBuilder bossBuilder)
		{
			HP = bossBuilder.Hp;
			Speed = bossBuilder.Speed;
			Weapon = bossBuilder.Weapon;
		}


		public void BossAttack()
		{
			adapter.BossAttack();
		}
	}
}
