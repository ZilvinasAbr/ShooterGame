using System;
using Shooter.Interfaces;

namespace Shooter.Classes
{
	public class Bazooka : Weapon, IWeapon
	{
		public void Shoot()
		{
		    Console.WriteLine("Bazooka shoots");
		}
	}
}
