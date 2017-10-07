using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Shooter.Classes;
using Shooter.Enums;
using Shooter.Interfaces;
using Shooter.PatternClasses;

namespace Shooter
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        static void ObserverExample()
        {
            Console.WriteLine("Running example for L1");

            var player1 = new Player1 {LifePoints = 100};
            var enemies = new List<Enemy>
            {
                new Enemy(player1),
                new Enemy(player1),
                new Enemy(player1)
            };

            foreach (var enemy in enemies)
            {
                player1.AttachObserver(enemy);
            }

            Console.WriteLine("Test1:");
            player1.Notify();
            Console.WriteLine("Test2:");
            player1.LifePoints = 90;
            player1.DetachObserver(enemies[0]);
            player1.Notify();

			var weaponType = WeaponType.Pistol;
			IWeaponFactory factory = null;

			switch(weaponType)
			{
				case WeaponType.Pistol:
					factory = new PistolFactory();
					break;
				case WeaponType.Bazooka:
					factory = new BazookaFactory();
					break;
				case WeaponType.Shotgun:
					factory = new ShotgunFactory();
					break;
			}

			var weapon = factory.CreateWeapon();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ObserverExample();

            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
