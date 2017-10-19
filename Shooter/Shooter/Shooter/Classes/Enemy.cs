using Shooter.Interfaces;
using System;

namespace Shooter.Classes
{
    public abstract class Enemy : IEnemy, IEnemyObserver
    {
        private readonly IPlayer _player;
        protected IWeapon Weapon;
        private int _playerLifePoints;
        private int LifePoints;

        protected Enemy(IWeapon weapon, IPlayer player, int lifePoints)
        {
            Weapon = weapon;
            _player = player;
            LifePoints = lifePoints;
        }

        public int GetLifePoints()
        {
            return LifePoints;
        }

        public void SetLifePoints(int lifePoints)
        {
            LifePoints = lifePoints;
        }

        public abstract void Attack();

		public virtual void Update()
        {
            _playerLifePoints = _player.LifePoints;
            Console.WriteLine($"Enemy notified of life points {_playerLifePoints}");
        }
    }
}
