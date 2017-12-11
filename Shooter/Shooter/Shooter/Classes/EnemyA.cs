using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Interfaces;
using Shooter.PatternClasses;

namespace Shooter.Classes
{
    public class EnemyA : Enemy
    {
        public EnemyA(IPathFinding pathFinder, IWeapon weapon, IPlayer player, double lifePoints, Vector2 position, Texture2D texture, IActionState state) : base(pathFinder, weapon, player, lifePoints, position, texture, state)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public override void Attack()
        {
            Weapon.Shoot();
        }

        public override void Accept(IEnemyVisitor enemyVisitor)
        {
            enemyVisitor.Visit(this);
        }

        public override void TakeDamage(double damage)
        {
            ParentEnemy?.TakeDamage(damage / 3);

            LifePoints = LifePoints - damage;
            if (LifePoints <= 0)
            {
                Alive = false;
            }
        }
    }
}
