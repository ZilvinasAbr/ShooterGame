using System;

namespace Shooter.Classes
{
	public class Bazooka : Weapon
	{
		public Bazooka() : base("Bazooka")
		{

		}

		public override void Shoot()
		{
		    Console.WriteLine("Bazooka shoots");
		}
	}
}
