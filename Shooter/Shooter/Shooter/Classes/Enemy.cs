using Shooter.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.PatternClasses;

namespace Shooter.Classes
{
    public abstract class Enemy : IEnemy, IEnemyObserver, IMapObject, EnemyPrototype
    {
        public Vector2 Position { get; set; }
        public int LifePoints { get; set; }
        public Texture2D Texture { get; set; }
        public IActionState CurrentState { get; set; }

        private readonly IPlayer _player;
        protected IWeapon Weapon;
        protected IPathFinding PathFinder;

        public abstract void Draw(SpriteBatch spriteBatch);

        // Updates Enemies ActionState, if it sees enemy, action
        // sets to ShootingState, otherwise MovingState
        public void Update()
        {
            
        }

        protected Enemy(IPathFinding pathFinder, IWeapon weapon, IPlayer player, int lifePoints, Vector2 position, Texture2D texture)
        {
            PathFinder = pathFinder;
            Weapon = weapon;
            LifePoints = lifePoints;
            Position = position;
            Texture = texture;
            CurrentState = new MovingState();
            _player = player;
            _player.AttachObserver(this);
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

        public void DoAction()
        {
            CurrentState.DoAction(this);
        }
        
        public virtual void UpdateObserver()
        {
            CurrentState.DoAction(this);
            Logger.Instance.Info($"Enemy notified of player position {_player.Position}");
            var start = new Point((int)Position.X, (int)Position.Y);
            var end = new Point((int) _player.Position.X, (int) _player.Position.Y);
            var nextPoint = PathFinder.NextPoint(start, end);
            
            var newPosition = new Vector2(nextPoint.X, nextPoint.Y);
            if (newPosition != _player.Position)
            {
                Position = newPosition;
            }
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
            _player.AttachObserver(enemy);
            return enemy;
        }
    }
}
