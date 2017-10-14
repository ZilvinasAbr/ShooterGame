using System;

namespace BridgeTest
{
    class BigEnemy : Enemy
    {
        public BigEnemy(IGun gun) : base(gun)
        {
        }

        public override void Attack()
        {
            Gun.Shoot();
            Console.WriteLine("Big enemy attacks");
        }
    }
}
