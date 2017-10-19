using Shooter.Interfaces;

namespace Shooter.Classes
{
    public class EnemyB : Enemy
    {
        public EnemyB(IWeapon weapon, IPlayer player, int lifePoints) : base(weapon, player, lifePoints)
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
