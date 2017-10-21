﻿using Shooter.Interfaces;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter.Classes
{
    public abstract class Enemy : IEnemy, IEnemyObserver, IMapObject
    {
        public Vector2 Position { get; set; }
        public int LifePoints { get; set; }
        public abstract void Draw(SpriteBatch spriteBatch);

        private readonly IPlayer _player;
        protected IWeapon Weapon;
        private int _playerLifePoints;

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

		public virtual void Update()
        {
            _playerLifePoints = _player.LifePoints;
            Console.WriteLine($"Enemy notified of life points {_playerLifePoints}");
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
