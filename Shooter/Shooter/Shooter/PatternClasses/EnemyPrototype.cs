using Shooter.Classes;

namespace Shooter.FactoryClasses
{
    public class EnemyPrototype
    {
        private Enemy Prototype;

        public EnemyPrototype(Enemy prototype)
        {
            Prototype = prototype;
        }

        public Enemy Clone()
        {
            return Prototype.Clone();
        }

        public Enemy DeepCopy()
        {
            return Prototype.DeepCopy();
        }
    }
}
