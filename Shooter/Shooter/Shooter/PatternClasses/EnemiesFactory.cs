using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Classes;
using Shooter.Enums;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
    public abstract class EnemiesFactory
    {
        public abstract Enemy CreateEnemy(IPathFinding pathFinder, EnemyType type, IWeapon weapon, IPlayer player, int lifePoints, Vector2 position, Texture2D texture);
    }
}