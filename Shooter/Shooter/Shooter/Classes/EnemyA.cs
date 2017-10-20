using Microsoft.Xna.Framework;
using Shooter.Interfaces;

namespace Shooter.Classes
{
    public class EnemyA : Enemy
    {
        public EnemyA(IWeapon weapon, IPlayer player, int lifePoints,  Vector2 position) : base(weapon, player, lifePoints, position)
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
