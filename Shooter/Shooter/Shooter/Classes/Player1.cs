using Shooter.Interfaces;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shooter.Classes
{
    class Player1 : IPlayer, IPlayerSubject, IMapObject
    {
        public Vector2 Position { get; set; }
        private readonly IList<IEnemyObserver> _enemyObservers;

        public int LifePoints { get; set; }

        public Player1()
        {
            _enemyObservers = new List<IEnemyObserver>();
        }

        public Player1(Vector2 position)
        {
            Position = position;
            _enemyObservers = new List<IEnemyObserver>();
        }

        public void AttachObserver(IEnemyObserver observer)
        {
            _enemyObservers.Add(observer);
        }

        public void DetachObserver(IEnemyObserver observer)
        {
            _enemyObservers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var enemyObserver in _enemyObservers)
            {
                enemyObserver.Update();
            }
        }
    }
}
