using Shooter.Classes;

namespace Shooter.PatternClasses
{
    public class EnemyKiller : IEnemyVisitor
    {
        public void Visit(EnemyA enemyA)
        {
            enemyA.Die();
        }

        public void Visit(EnemyB enemyB)
        {
            enemyB.Die();
        }

        public void Visit(Boss boss)
        {
            boss.Die();
        }
    }
}
