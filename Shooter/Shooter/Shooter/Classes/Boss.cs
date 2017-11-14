using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Interfaces;
using Shooter.PatternClasses;
using System.Collections.Generic;

namespace Shooter.Classes
{
	public class Boss : Enemy, IBoss
	{
        private IList<Enemy> minions;

		public Boss(IPathFinding pathFinder, IWeapon weapon, IPlayer player, int lifePoints, Vector2 position, Texture2D texture) : base(pathFinder, weapon, player, lifePoints, position, texture)
		{
            minions = new List<Enemy>();
		}

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public override void Attack()
        {
        }

		public void BossAttack()
		{
		}

        public void AddMinion(Enemy enemy)
        {
            minions.Add(enemy);
        }

        public void RemoveMinion(Enemy enemy)
        {
            minions.Remove(enemy);
        }

        public override void Die()
        {
            Alive = false;
            foreach(Enemy minion in minions)
            {
                minion.Die();
            }
        }

        public Enemy GetMinion(int index)
        {
            return minions[index];
        }

        public IList<Enemy> GetMinions()
        {
            return minions;
        }

        public override void Accept(IEnemyVisitor enemyVisitor)
        {
            foreach(Enemy minion in minions)
            {
                minion.Accept(enemyVisitor);
            }

            enemyVisitor.Visit(this);
        }
    }
}
