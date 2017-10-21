using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter.Classes
{
    public interface IMapObject
    {
        Vector2 Position { get; set; }
        void Draw(SpriteBatch spriteBatch);
    }
}
