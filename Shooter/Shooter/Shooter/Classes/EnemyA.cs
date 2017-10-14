﻿using Shooter.Interfaces;

namespace Shooter.Classes
{
    class EnemyA : Enemy, IEnemy
    {
        private IWeapon _weapon;

        public EnemyA(IWeapon weapon, IPlayer player) : base(player)
        {
            _weapon = weapon;
        }

        public void SetWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public override void Attack()
        {
            _weapon.Shoot();
        }
    }
}
