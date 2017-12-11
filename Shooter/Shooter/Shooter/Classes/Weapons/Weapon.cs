using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Interfaces;
using Shooter.Utils;

namespace Shooter.Classes.Weapons
{
    public abstract class Weapon : IWeapon, IMapObject
    {
        public Texture2D Texture { get; set; }
        public string TextureName { get; set; }
        public IMap Map { get; set; }
        public Vector2 Position { get; set; }
        public string Name { get; set; }
        public double Damage { get; set; }
        public decimal Price { get; set; }
        public int Range { get; set; }
        public int Ammo { get; set; }
		public bool SlowsSpeed { get; set; }

        protected Weapon()
        {
            var randomPosition = new Random();
            Position = new Vector2(randomPosition.Next(0, GameSettings.MapSize) * GameSettings.TileSize, randomPosition.Next(0, GameSettings.MapSize) * GameSettings.TileSize);
        }

        public void PrepareToShoot(double baseDamage)
        {
            if (IsWeaponReloadable())
            {
                if (ShouldReload())
                {
                    Reload();
                }
                else
                {
                    Shoot(baseDamage);
                }
            }
            else
            {
                Shoot(baseDamage);
            }
        }

        protected abstract bool IsWeaponReloadable();
        protected abstract void Reload();
        protected abstract bool ShouldReload();
        protected abstract void Shoot(double baseDamage);

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
            Map.BroadcastToEnemies(message, this);
        }
    }
}
