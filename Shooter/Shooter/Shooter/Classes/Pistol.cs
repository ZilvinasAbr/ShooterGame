using System;
using Shooter.Interfaces;

namespace Shooter.Classes
{
	public class Pistol : Weapon, IWeapon
	{
		public void Shoot()
		{
		    Console.WriteLine("Pistol shoots");
		}
	}
}
