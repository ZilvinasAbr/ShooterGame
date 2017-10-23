using Shooter.Classes;

namespace Shooter.PatternClasses
{
    public interface EnemyPrototype
    {
        Enemy Clone();

        Enemy DeepCopy();
    }
}
