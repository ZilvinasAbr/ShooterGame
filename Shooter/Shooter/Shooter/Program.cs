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
            Logger.Instance.Info("Running Observer Example");

            var mockPosition = Vector2.Zero;
            var mockMap = new Map(16, 16);
            var mockPathFinder = new PathFindingAdapter(mockMap);

            var player1 = new Player1 {LifePoints = 100};
            var pistol = new Pistol();
            var enemies = new List<IEnemyObserver>
            {
                new EnemyA(mockPathFinder, pistol, player1, 50, mockPosition, null),
                new EnemyA(mockPathFinder, pistol, player1, 50, mockPosition, null),
                new EnemyA(mockPathFinder, pistol, player1, 50, mockPosition, null)
            };

            foreach (var enemy in enemies)
            {
                player1.AttachObserver(enemy);
            }

            Logger.Instance.Info("Test1:");
            player1.Notify();
            Logger.Instance.Info("Test2:");
            player1.LifePoints = 90;
            player1.DetachObserver(enemies[0]);
            player1.Notify();
        }

        private static void FactoryExample()
        {
            Logger.Instance.Info("Running Factory Example");
            var mockPosition = Vector2.Zero;
            var mockMap = new Map(16, 16);
            var mockPathFinder = new PathFindingAdapter(mockMap);
            var player1 = new Player1 { LifePoints = 100 };
            var pistol = new Pistol();
            var enemiesFactory = new EnemiesConcreteFactory();
            var enemyA = enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Small, pistol, player1, 50, mockPosition, null);
            Logger.Instance.Info("First enemy has " + enemyA.LifePoints + " life points and his type is " + enemyA.GetType());
            var enemyB = enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Big, pistol, player1, 75, mockPosition, null);
            Logger.Instance.Info("Second enemy has " + enemyB.LifePoints + " life points and his type is " + enemyB.GetType());
        }

        private static void PrototypeExample()
        {
            Logger.Instance.Info("Running Prototype Example");
            var mockPosition = Vector2.Zero;
            var mockMap = new Map(16, 16);
            var mockPathFinder = new PathFindingAdapter(mockMap);
            var player1 = new Player1 { LifePoints = 100 };
            var pistol = new Pistol();

            EnemiesFactory enemiesFactory = new EnemiesConcreteFactory();
            var enemyA = enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Small, pistol, player1, 50, mockPosition, null);

            Logger.Instance.Info("First enemy has " + enemyA.LifePoints + " life points and his hash code is " + enemyA.GetHashCode() + " and weapon's hash code is " + enemyA.GetWeapon().GetHashCode());

            var enemyA1 = enemyA.Clone();
            Logger.Instance.Info("Cloned enemy has " + enemyA1.LifePoints + " life points and his hash code is " + enemyA1.GetHashCode() + " and weapon's hash code is " + enemyA1.GetWeapon().GetHashCode());
            var enemyA2 = enemyA.Clone();
            Logger.Instance.Info("Second Cloned enemy has " + enemyA2.LifePoints + " life points and his hash code is " + enemyA2.GetHashCode() + " and weapon's hash code is " + enemyA2.GetWeapon().GetHashCode());

            var enemyA3 = enemyA.DeepCopy();
            Logger.Instance.Info("Deep Cloned enemy has " + enemyA3.LifePoints + " life points and his hash code is " + enemyA3.GetHashCode() + " and weapon's hash code is " + enemyA3.GetWeapon().GetHashCode());
            var enemyA4 = enemyA.DeepCopy();
            Logger.Instance.Info("Second Deep Cloned enemy has " + enemyA4.LifePoints + " life points and his hash code is " + enemyA4.GetHashCode() + " and weapon's hash code is " + enemyA4.GetWeapon().GetHashCode());
        }

        private static void BridgeExample()
        {
            Logger.Instance.Info("Running Bridge Example");

            var mockPosition = Vector2.Zero;
            var mockMap = new Map(16, 16);
            var mockPathFinder = new PathFindingAdapter(mockMap);

            IPlayer player = new Player1();
            IWeapon bazooka = new Bazooka();
            IWeapon pistol = new Pistol();

            Enemy enemyAWithBazooka = new EnemyA(mockPathFinder, bazooka, player, 50, mockPosition, null);
            Enemy enemyBWithPistol = new EnemyB(mockPathFinder, pistol, player, 50, mockPosition, null);

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
            var mockMap = new Map(mapSize, mapSize);
            IPathFinding pathfindingAdapter = new PathFindingAdapter(mockMap);

            var nextPoint = pathfindingAdapter.NextPoint(new Point(0, 0), new Point(0, 5));

            Logger.Instance.Info($"Next point: {nextPoint}");
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
            PrototypeExample();

            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
