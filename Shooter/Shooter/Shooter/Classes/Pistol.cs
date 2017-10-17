using System;
using Shooter.Interfaces;

namespace Shooter.Classes
{
	public class Pistol : Weapon
	{
		public override void Shoot()
		{
		    Console.WriteLine("Pistol shoots");
		}
	}
}
