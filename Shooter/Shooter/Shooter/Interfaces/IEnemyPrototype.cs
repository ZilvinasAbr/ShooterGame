using Shooter.Classes;

namespace Shooter.PatternClasses
{
    public interface IEnemyPrototype
    {
        Enemy Clone();

        Enemy DeepCopy();
    }
}
