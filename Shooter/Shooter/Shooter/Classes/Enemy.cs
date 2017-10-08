using Shooter.Interfaces;
using System;

namespace Shooter.Classes
{
    abstract class Enemy : IEnemy, IEnemyObserver
    {
        private readonly IPlayer _player;
        private int _playerLifePoints;

        protected Enemy(IPlayer player)
        {
            _player = player;
        }

        public abstract void Attack();

		public void Update()
        {
            _playerLifePoints = _player.LifePoints;
            Console.WriteLine($"Enemy notified of life points {_playerLifePoints}");
        }
    }
}
