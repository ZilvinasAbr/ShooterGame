using Microsoft.Xna.Framework;
using Shooter.Interfaces;

namespace Shooter.Classes
{
    public class EnemyB : Enemy
    {
        public EnemyB(IWeapon weapon, IPlayer player, int lifePoints, Vector2 position) : base(weapon, player, lifePoints, position)
        {
        }

        public void SetWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public override void Attack()
        {
            Weapon.Shoot();
        }
    }
}
