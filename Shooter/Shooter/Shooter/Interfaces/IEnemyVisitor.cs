using Shooter.Classes;

namespace Shooter.PatternClasses
{
    public interface IEnemyVisitor
    {
        void Visit(EnemyA enemyA);
        void Visit(EnemyB enemyB);
        void Visit(Boss boss);
    }
}
