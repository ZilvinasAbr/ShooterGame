using System;

namespace Shooter.Classes
{
    class Enemy : IEnemy, IEnemyObserver
    {
        private readonly IPlayer _player;
        private int _playerLifePoints;

        public Enemy(IPlayer player)
        {
            _player = player;
        }

        public void Update()
        {
            _playerLifePoints = _player.LifePoints;
            Console.WriteLine($"Enemy notified of life points {_playerLifePoints}");
        }
    }
}
