using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Shooter.Classes;

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
