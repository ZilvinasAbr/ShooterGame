using Shooter.Interfaces;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.FactoryClasses;

namespace Shooter.Classes
{
    public abstract class Enemy : IEnemy, IEnemyObserver, IMapObject, EnemyPrototype
    {
        public Vector2 Position { get; set; }
        public int LifePoints { get; set; }
        
        private readonly IPlayer _player;
        protected IWeapon Weapon;

        public abstract void Draw(SpriteBatch spriteBatch);

        protected Enemy(IWeapon weapon, IPlayer player, int lifePoints, Vector2 position)
        {
            Weapon = weapon;
            _player = player;
            LifePoints = lifePoints;
            Position = position;
        }

        public IWeapon GetWeapon()
        {
            return Weapon;
        }

        public void SetWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public abstract void Attack();
        
		public virtual void UpdateObserver()
        {
            Console.WriteLine($"Enemy notified of life points {_player.LifePoints}");
        }

        public Enemy Clone()
        {
            return (Enemy)this.MemberwiseClone();
        }

        public Enemy DeepCopy()
        {
            Enemy enemy = (Enemy)this.MemberwiseClone();
            IWeapon weapon = enemy.GetWeapon().Clone();
            enemy.SetWeapon(weapon);
            return enemy;
        }
    }
}
