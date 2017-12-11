using System;
using Shooter.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.PatternClasses;

namespace Shooter.Classes.Enemies
{
    public abstract class Enemy : IEnemy, IEnemyObserver, IMapObject, IEnemyPrototype
    {
        public const string EnemySpawned = "EnemySpawned";

        public IMap Map { get; set; }
        public Vector2 Position { get; set; }
        public double LifePoints { get; set; }
        public double BaseDamage { get; set; } = 0;
        public Texture2D Texture { get; set; }
	    public IActionState CurrentState { get; set; }
	    protected bool Alive;

        protected Enemy ParentEnemy;
        private readonly IPlayer _player;
        protected IWeapon Weapon;
        protected IPathFinding PathFinder;

        public abstract void Draw(SpriteBatch spriteBatch);

        public void Receive(string message)
        {
            if (message == EnemySpawned)
            {
                Logger.Instance.Info("Enemy spawned, base damage increases");
                BaseDamage += BaseDamage * 0.2;
            }
        }

        public void Send(string message)
        {
            Map?.BroadcastToEnemies(message, this);
        }

        // Updates Enemies ActionState, if it sees enemy, action
        // sets to ShootingState, otherwise MovingState
        public void Update()
        {
            CurrentState.DoAction(this);
        }

        protected Enemy(IPathFinding pathFinder, IWeapon weapon, IPlayer player, double lifePoints, Vector2 position, Texture2D texture, IActionState state, IMap map)
        {
            PathFinder = pathFinder;
            Weapon = weapon;
            LifePoints = lifePoints;
            Position = position;
            Texture = texture;
            CurrentState = state;
            _player = player;
            Map = map;
            _player.AttachObserver(this);
            Alive = true;
            Send(EnemySpawned);
        }

        public void SetParentEnemy(Enemy parent)
        {
            ParentEnemy = parent;
        }

        public IWeapon GetWeapon()
        {
            return Weapon;
        }

        public void SetWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public virtual void TakeDamage(double damage)
        {
            ParentEnemy?.TakeDamage(damage/2);

            LifePoints = LifePoints - damage;
            if(LifePoints <= 0)
            {
                Alive = false;
            }
        }

        public virtual void Die()
        {
            Alive = false;
        }

        public bool IsAlive()
        {
            return Alive;
        }

        public abstract void Attack();

        public void DoAction()
        {
            CurrentState.DoAction(this);
        }

        public void MoveToPlayer()
        {
            var start = new Point((int)Position.X, (int)Position.Y);
            var end = new Point((int)_player.Position.X, (int)_player.Position.Y);
            var nextPoint = PathFinder.NextPoint(start, end);

            var newPosition = new Vector2(nextPoint.X, nextPoint.Y);
            if (newPosition != _player.Position)
            {
                Position = newPosition;
            }
        }
        
        public virtual void UpdateObserver()
        {
            DoAction();
            Logger.Instance.Info($"Enemy notified of player position {_player.Position}");
        }

        public virtual void Idle()
        {
            // Do nothing
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

        public abstract void Accept(IEnemyVisitor enemyVisitor);
    }
}
