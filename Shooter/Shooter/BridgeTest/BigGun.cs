using System;

namespace BridgeTest
{
    public class BigGun : IGun
    {
        public void Shoot()
        {
            Console.WriteLine("Big Gun shot fired");
        }
    }
}
