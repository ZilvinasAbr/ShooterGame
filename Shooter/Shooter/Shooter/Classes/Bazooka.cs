using System;
using Shooter.Interfaces;

namespace Shooter.Classes
{
	public class Bazooka : Weapon
	{
		public override void Shoot()
		{
		    Console.WriteLine("Bazooka shoots");
		}
	}
}
