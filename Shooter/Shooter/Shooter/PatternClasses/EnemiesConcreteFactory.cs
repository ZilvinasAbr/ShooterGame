using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Classes;
using Shooter.Enums;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
    public class EnemiesConcreteFactory : EnemiesFactory
    {
        public override Enemy CreateEnemy(EnemyType type, IWeapon weapon, IPlayer player, int lifePoints, Vector2 position, Texture2D texture)
        {
            switch (type)
            {
                case EnemyType.Small:
                    return new EnemyA(weapon, player, lifePoints, position, texture);
                case EnemyType.Big:
                    return new EnemyB(weapon, player, lifePoints, position, texture);
                default:
                    return null;
            }
        }
    }
}