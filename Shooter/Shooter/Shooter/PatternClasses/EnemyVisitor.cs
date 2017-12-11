using Shooter.Classes;
using Shooter.Classes.Enemies;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
    public class EnemyVisitor : IEnemyVisitor
    {
        public void Visit(EnemyA enemyA)
        {
            Logger.Instance.Info("Displaying EnemyA with " + enemyA.LifePoints + " HP.");
        }

        public void Visit(EnemyB enemyB)
        {
            Logger.Instance.Info("Displaying EnemyB with " + enemyB.LifePoints + " HP.");
        }

        public void Visit(Boss boss)
        {
            Logger.Instance.Info("Displaying Boss with " + boss.LifePoints + " HP.");
        }
    }
}
