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
