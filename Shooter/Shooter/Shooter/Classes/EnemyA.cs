using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Interfaces;

namespace Shooter.Classes
{
    public class EnemyA : Enemy
    {
        public EnemyA(IWeapon weapon, IPlayer player, int lifePoints, Vector2 position, Texture2D texture) : base(weapon, player, lifePoints, position, texture)
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
    }
}
