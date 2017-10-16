using System;
using System.Collections.Generic;
using DeenGames.Utils.AStarPathFinder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            Console.WriteLine("Running Observer Example");

            var player1 = new Player1 {LifePoints = 100};
            var pistol = new Pistol();
            var enemies = new List<Enemy>
            {
                new EnemyA(pistol, player1),
                new EnemyA(pistol, player1),
                new EnemyA(pistol, player1)
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

        private static void BridgeExample()
        {
            Console.WriteLine("Running Bridge Example");

            IPlayer player = new Player1();
            IWeapon bazooka = new Bazooka();
            IWeapon pistol = new Pistol();

            Enemy enemyAWithBazooka = new EnemyA(bazooka, player);
            Enemy enemyBWithPistol = new EnemyB(pistol, player);

            enemyAWithBazooka.Attack();
            enemyBWithPistol.Attack();
        }

        private static void SingletonExample()
        {
            Logger.Instance.Error("Error message");
            Logger.Instance.Info("Info message");
            Logger.Instance.Debug("Debug message");
        }

        private static void ProbablyGuessAbstractFactoryExample()
        {
            var weaponType = WeaponType.Pistol;
            IWeaponFactory factory = null;

            switch (weaponType)
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

        private static void AdapterExample()
        {
            var map = new Map();
            IPathFinding pathfindingAdapter = new PathfindingAdapter();

            var nextPoint = pathfindingAdapter.NextPoint(map, new Point(0, 0), new Point(0, 5));

            Console.WriteLine($"Next point: {nextPoint}");
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ObserverExample();
            BridgeExample();
            ProbablyGuessAbstractFactoryExample();
            SingletonExample();
            AdapterExample();

            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
