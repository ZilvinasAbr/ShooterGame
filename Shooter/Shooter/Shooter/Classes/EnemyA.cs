using Shooter.Interfaces;

namespace Shooter.Classes
{
    public class EnemyA : Enemy
    {
        public EnemyA(IWeapon weapon, IPlayer player, int lifePoints) : base(weapon, player, lifePoints)
        {
        }

        public override void Attack()
        {
            Weapon.Shoot();
        }
    }
}
