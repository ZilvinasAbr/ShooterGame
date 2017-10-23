using Microsoft.Xna.Framework;
using Shooter.Classes;
using Shooter.Enums;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
    public abstract class EnemiesFactory
    {
        public abstract Enemy CreateEnemy(EnemyType type, IWeapon weapon, IPlayer player, int lifePoints, Vector2 position);
    }
}