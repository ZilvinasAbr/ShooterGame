using Shooter.Classes.Enemies;

namespace Shooter.Interfaces
{
    public interface IEnemyPrototype
    {
        Enemy Clone();

        Enemy DeepCopy();
    }
}
