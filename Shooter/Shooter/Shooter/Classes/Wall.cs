using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter.Classes
{
    public class Wall : IMapObject
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
