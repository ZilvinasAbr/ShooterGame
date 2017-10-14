using System;

namespace BridgeTest
{
    class SmallEnemy : Enemy
    {
        public SmallEnemy(IGun gun) : base(gun)
        {
        }

        public override void Attack()
        {
            Gun.Shoot();
            Console.WriteLine("Small enemy attacks");
        }
    }
}
