using Shooter.Interfaces;
using System;
using Microsoft.Xna.Framework;

namespace Shooter.Classes
{
    public abstract class Enemy : IEnemy, IEnemyObserver, IMapObject
    {
        public Vector2 Position { get; set; }

        private readonly IPlayer _player;
        protected IWeapon Weapon;
        private int _playerLifePoints;
        private int _lifePoints;

        protected Enemy(IWeapon weapon, IPlayer player, int lifePoints, Vector2 position)
        {
            Weapon = weapon;
            _player = player;
            _lifePoints = lifePoints;
            Position = position;
        }

        public int GetLifePoints()
        {
            return _lifePoints;
        }

        public void SetLifePoints(int lifePoints)
        {
            _lifePoints = lifePoints;
        }

        public abstract void Attack();

		public virtual void Update()
        {
            _playerLifePoints = _player.LifePoints;
            Console.WriteLine($"Enemy notified of life points {_playerLifePoints}");
        }
    }
}
