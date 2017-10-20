using Shooter.Classes;
using Shooter.Enums;
using Shooter.Interfaces;

namespace Shooter.FactoryClasses
{
    public class EnemiesFactory
    {
        public static Enemy CreateEnemy(EnemyType type, IWeapon weapon, IPlayer player, int lifePoints)
        {
            switch(type)
            {
                case EnemyType.Small:
                    return new EnemyA(weapon, player, lifePoints);
                case EnemyType.Big:
                    return new EnemyB(weapon, player, lifePoints);
                default:
                    return null;
            }
        }
    }
}
