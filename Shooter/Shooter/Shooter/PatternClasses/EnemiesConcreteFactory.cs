using Microsoft.Xna.Framework;
using Shooter.Classes;
using Shooter.Enums;
using Shooter.Interfaces;

namespace Shooter.FactoryClasses
{
    public class EnemiesConcreteFactory : EnemiesFactory
    {
        public override Enemy CreateEnemy(EnemyType type, IWeapon weapon, IPlayer player, int lifePoints, Vector2 position)
        {
            switch (type)
            {
                case EnemyType.Small:
                    return new EnemyA(weapon, player, lifePoints, position);
                case EnemyType.Big:
                    return new EnemyB(weapon, player, lifePoints, position);
                default:
                    return null;
            }
        }
    }
}