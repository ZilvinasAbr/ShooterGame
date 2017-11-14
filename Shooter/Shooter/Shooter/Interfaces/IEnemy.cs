using Shooter.PatternClasses;

namespace Shooter.Interfaces
{
    public interface IEnemy
    {
		void Attack();
        void Accept(IEnemyVisitor enemyVisitor);
    }
}
