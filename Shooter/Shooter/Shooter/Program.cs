using System;
using System.Collections.Generic;
using DeenGames.Utils.AStarPathFinder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Classes;
using Shooter.Enums;
using Shooter.Interfaces;
using Shooter.PatternClasses;
using Shooter.FactoryClasses;

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

            var mockPosition = Vector2.Zero;

            var player1 = new Player1 {LifePoints = 100};
            var pistol = new Pistol();
            var enemies = new List<IEnemyObserver>
            {
                new EnemyA(pistol, player1, 50, mockPosition),
                new EnemyA(pistol, player1, 50, mockPosition),
                new EnemyA(pistol, player1, 50, mockPosition)
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

        private static void FactoryExample()
        {
            var mockPosition = Vector2.Zero;
            Console.WriteLine("Running Factory Example");
            var player1 = new Player1 { LifePoints = 100 };
            var pistol = new Pistol();
            var enemyA = EnemiesFactory.CreateEnemy(EnemyType.Small, pistol, player1, 50, mockPosition);
            Console.WriteLine("First enemy has " + enemyA.GetLifePoints() + " life points and his type is " + enemyA.GetType());
            var enemyB = EnemiesFactory.CreateEnemy(EnemyType.Big, pistol, player1, 75, mockPosition);
            Console.WriteLine("Second enemy has " + enemyB.GetLifePoints() + " life points and his type is " + enemyB.GetType());
        }

        private static void BridgeExample()
        {
            Console.WriteLine("Running Bridge Example");

            var mockPosition = Vector2.Zero;
            IPlayer player = new Player1();
            IWeapon bazooka = new Bazooka();
            IWeapon pistol = new Pistol();

            Enemy enemyAWithBazooka = new EnemyA(bazooka, player, 50, mockPosition);
            Enemy enemyBWithPistol = new EnemyB(pistol, player, 50, mockPosition);

            enemyAWithBazooka.Attack();
            enemyBWithPistol.Attack();
        }

        private static void SingletonExample()
        {
            Logger.Instance.Error("Error message");
            Logger.Instance.Info("Info message");
            Logger.Instance.Debug("Debug message");
        }

        private static void AbstractFactoryExample()
        {
            var weaponFamily = WeaponType.Heavy;
			var weapon = WeaponName.Bazooka;

			var factory = WeaponFactory.CreateFactory(weaponFamily);
			var createdWeapon = factory.CreateWeapon(weapon);
        }

        private static void AdapterExample()
        {
            int mapSize = 32;
            var map = new Map(mapSize, mapSize);
            IPathFinding pathfindingAdapter = new PathFindingAdapter(mapSize, mapSize);

            var nextPoint = pathfindingAdapter.NextPoint(map.MapObjects, new Point(0, 0), new Point(0, 5));

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
			AbstractFactoryExample();
            SingletonExample();
            AdapterExample();
            FactoryExample();

            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
