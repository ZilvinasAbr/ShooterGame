using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Interfaces;
using System;

namespace Shooter.Classes
{
    public abstract class Weapon : IWeapon, IMapObject
    {
        public Texture2D Texture { get; set; }
        public string TextureName { get; set; }
        public IMap Map { get; set; }
        public Vector2 Position { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public decimal Price { get; set; }
        public int Range { get; set; }
        public int Magazine { get; set; }
		public bool SlowsSpeed { get; set; }

        protected Weapon()
        {
            var randomPosition = new Random();
            Position = new Vector2(randomPosition.Next(0, GameSettings.MapSize) * GameSettings.TileSize, randomPosition.Next(0, GameSettings.MapSize) * GameSettings.TileSize);
        }

        public abstract void Shoot();

        public Weapon Clone()
        {
            return (Weapon)this.MemberwiseClone();
        }

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
            Map.Broadcast(message, this);
        }
    }
}
