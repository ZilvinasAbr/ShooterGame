using Shooter.Classes.Enemies;

namespace Shooter.Interfaces
{
    public interface IEnemyVisitor
    {
        void Visit(EnemyA enemyA);
        void Visit(EnemyB enemyB);
        void Visit(Boss boss);
    }
}
