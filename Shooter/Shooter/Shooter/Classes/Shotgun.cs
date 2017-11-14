using System;

namespace Shooter.Classes
{
	public class Shotgun : HeavyWeapon
	{
		public Shotgun()
		{

		}

        public override void Shoot()
        {
            Console.WriteLine("Shotgun shoots");
        }
    }
}
