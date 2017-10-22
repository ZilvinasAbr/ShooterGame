using Shooter.Classes;

namespace Shooter.FactoryClasses
{
    public interface EnemyPrototype
    {
        Enemy Clone();

        Enemy DeepCopy();
    }
}
