using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Interfaces;

namespace Shooter.Classes
{
    public class Wall : IMapObject
    {
        public Texture2D Texture { get; set; }
        public IMap Map { get; set; }
        public Vector2 Position { get; set; }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Receive(string message)
        {
            Console.WriteLine($"Received a message: {message}");
        }

        public void Send(string message)
        {
            Map.BroadcastToEnemies(message, this);
        }
    }
}
