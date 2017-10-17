using Shooter.Interfaces;
using System;

namespace Shooter.Classes
{
    public abstract class Enemy : IEnemy, IEnemyObserver
    {
        private readonly IPlayer _player;
        protected IWeapon Weapon;
        private int _playerLifePoints;

        protected Enemy(IWeapon weapon, IPlayer player)
        {
            Weapon = weapon;
            _player = player;
        }

        public abstract void Attack();

		public virtual void Update()
        {
            _playerLifePoints = _player.LifePoints;
            Console.WriteLine($"Enemy notified of life points {_playerLifePoints}");
        }
    }
}
