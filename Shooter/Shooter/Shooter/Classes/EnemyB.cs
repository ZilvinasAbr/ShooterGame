using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Interfaces;

namespace Shooter.Classes
{
    public class EnemyB : Enemy
    {
        public Texture2D Texture { get; set; }

        public EnemyB(IWeapon weapon, IPlayer player, int lifePoints, Vector2 position) : base(weapon, player, lifePoints, position)
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
