using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
	public class EnemyToBossAdapter
	{
		private readonly IEnemy _enemy;

		public EnemyToBossAdapter()
		{
			//_enemy = enemy;
		}

		public void BossAttack()
		{
			_enemy.Attack();
		}
	}
}
