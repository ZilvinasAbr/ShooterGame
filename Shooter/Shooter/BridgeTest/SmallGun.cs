using System;

namespace BridgeTest
{
    class SmallGun : IGun
    {
        public void Shoot()
        {
            Console.WriteLine("Small Gun shot fired");
        }
    }
}
