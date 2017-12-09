using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Interfaces;

namespace Shooter.Classes
{
    public interface IMapObject
    {
        IMap Map{ get; set; }
        Vector2 Position { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Receive(string message);
        void Send(string message);
    }
}
