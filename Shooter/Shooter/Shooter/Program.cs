using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Shooter.Classes;
using Shooter.Classes.Enemies;
using Shooter.Classes.Weapons;
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
			var enemyState = new EnemyStateFactory();

			var player1 = new Player1 { LifePoints = 100 };
			var pistol = new Pistol();
			var enemies = new List<IEnemyObserver>
			{
				new EnemyA(mockPathFinder, pistol, player1, 50, mockPosition, null, enemyState.GetState("Moving"), mockMap),
				new EnemyA(mockPathFinder, pistol, player1, 50, mockPosition, null, enemyState.GetState("Moving"), mockMap),
				new EnemyA(mockPathFinder, pistol, player1, 50, mockPosition, null, enemyState.GetState("Moving"), mockMap)
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
			var enemyState = new EnemyStateFactory();

			var enemyA = enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Small, pistol, player1, 50, mockPosition,
				null, enemyState.GetState("Moving"), mockMap);
			Logger.Instance.Info("First enemy has " + enemyA.LifePoints + " life points and his type is " +
								 enemyA.GetType());
			var enemyB =
				enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Big, pistol, player1, 75, mockPosition, null, enemyState.GetState("Moving"), mockMap);
			Logger.Instance.Info("Second enemy has " + enemyB.LifePoints + " life points and his type is " +
								 enemyB.GetType());
		}

		private static void PrototypeExample()
		{
			Logger.Instance.Info("Running Prototype Example");
			var mockPosition = Vector2.Zero;
			var mockMap = new Map(16, 16);
			var mockPathFinder = new PathFindingAdapter(mockMap);
			var player1 = new Player1 { LifePoints = 100 };
			var pistol = new Pistol();
			var enemyState = new EnemyStateFactory();

			EnemiesFactory enemiesFactory = new EnemiesConcreteFactory();
			var enemyA = enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Small, pistol, player1, 50, mockPosition,
				null, enemyState.GetState("Moving"), mockMap);

			Logger.Instance.Info("First enemy has " + enemyA.LifePoints + " life points and his hash code is " +
								 enemyA.GetHashCode() + " and weapon's hash code is " +
								 enemyA.GetWeapon().GetHashCode());

			var enemyA1 = enemyA.Clone();
			Logger.Instance.Info("Cloned enemy has " + enemyA1.LifePoints + " life points and his hash code is " +
								 enemyA1.GetHashCode() + " and weapon's hash code is " +
								 enemyA1.GetWeapon().GetHashCode());
			var enemyA2 = enemyA.Clone();
			Logger.Instance.Info("Second Cloned enemy has " + enemyA2.LifePoints +
								 " life points and his hash code is " + enemyA2.GetHashCode() +
								 " and weapon's hash code is " + enemyA2.GetWeapon().GetHashCode());

			var enemyA3 = enemyA.DeepCopy();
			Logger.Instance.Info("Deep Cloned enemy has " + enemyA3.LifePoints + " life points and his hash code is " +
								 enemyA3.GetHashCode() + " and weapon's hash code is " +
								 enemyA3.GetWeapon().GetHashCode());
			var enemyA4 = enemyA.DeepCopy();
			Logger.Instance.Info("Second Deep Cloned enemy has " + enemyA4.LifePoints +
								 " life points and his hash code is " + enemyA4.GetHashCode() +
								 " and weapon's hash code is " + enemyA4.GetWeapon().GetHashCode());
		}

		private static void CompositeExample()
		{
			Logger.Instance.Info("Running Composite Example");
			var mockPosition = Vector2.Zero;
			var mockMap = new Map(16, 16);
			var mockPathFinder = new PathFindingAdapter(mockMap);
			var player1 = new Player1 { LifePoints = 100 };
			var pistol = new Pistol();
			var enemyState = new EnemyStateFactory();

			var boss1 = new Boss(mockPathFinder, pistol, player1, 500, mockPosition, null, enemyState.GetState("Moving"), mockMap);
			var boss2 = new Boss(mockPathFinder, pistol, player1, 200, mockPosition, null, enemyState.GetState("Moving"), mockMap);

			EnemiesFactory enemiesFactory = new EnemiesConcreteFactory();
			var enemyA1 = enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Small, pistol, player1, 50, mockPosition,
				null, enemyState.GetState("Moving"), mockMap);
			var enemyB1 =
				enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Big, pistol, player1, 75, mockPosition, null, enemyState.GetState("Moving"), mockMap);
			var enemyA2 = enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Small, pistol, player1, 25, mockPosition,
				null, enemyState.GetState("Moving"), mockMap);
			var enemyB2 =
				enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Big, pistol, player1, 50, mockPosition, null, enemyState.GetState("Moving"), mockMap);

			boss1.AddMinion(enemyA1);
			boss1.AddMinion(boss2);
			boss1.AddMinion(enemyB1);

			boss2.AddMinion(enemyA2);
			boss2.AddMinion(enemyB2);


			Logger.Instance.Info("Boss1 has " + boss1.LifePoints + "HP. His minions:");
			int i = 1;
			foreach (Enemy enemy in boss1.GetMinions())
			{
				Logger.Instance.Info("Minion has " + enemy.LifePoints + "HP, his boss is Boss" + i + ".");
				if (enemy.GetType() == typeof(Boss))
				{
					i++;
					Boss temp = (Boss)enemy;
					Logger.Instance.Info("This minion is boss as well.");
					foreach (Enemy minion in temp.GetMinions())
					{
						Logger.Instance.Info("Minion has " + minion.LifePoints + "HP, his boss is Boss" + i + ".");
					}
					i--;
				}
			}
		}

		private static void VisitorExample()
		{
			Logger.Instance.Info("Running Visitor Example");

			var mockPosition = Vector2.Zero;
			var mockMap = new Map(16, 16);
			var mockPathFinder = new PathFindingAdapter(mockMap);
			var player1 = new Player1 { LifePoints = 100 };
			var pistol = new Pistol();
			var enemyState = new EnemyStateFactory();

			Boss boss1 = new Boss(mockPathFinder, pistol, player1, 500, mockPosition, null, enemyState.GetState("Moving"), mockMap);
			Boss boss2 = new Boss(mockPathFinder, pistol, player1, 200, mockPosition, null, enemyState.GetState("Moving"), mockMap);

			EnemiesFactory enemiesFactory = new EnemiesConcreteFactory();
			var enemyA1 = enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Small, pistol, player1, 50, mockPosition,
				null, enemyState.GetState("Moving"), mockMap);
			var enemyB1 =
				enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Big, pistol, player1, 75, mockPosition, null, enemyState.GetState("Moving"), mockMap);
			var enemyA2 = enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Small, pistol, player1, 25, mockPosition,
				null, enemyState.GetState("Moving"), mockMap);
			var enemyB2 =
				enemiesFactory.CreateEnemy(mockPathFinder, EnemyType.Big, pistol, player1, 50, mockPosition, null, enemyState.GetState("Moving"), mockMap);

			boss1.AddMinion(enemyA1);
			boss1.AddMinion(boss2);
			boss1.AddMinion(enemyB1);

			boss2.AddMinion(enemyA2);
			boss2.AddMinion(enemyB2);

			boss1.Accept(new EnemyVisitor());
		}

		private static void BridgeExample()
		{
			Logger.Instance.Info("Running Bridge Example");

			var mockPosition = Vector2.Zero;
			var mockMap = new Map(16, 16);
			var mockPathFinder = new PathFindingAdapter(mockMap);
			var enemyState = new EnemyStateFactory();

			IPlayer player = new Player1();
			IWeapon bazooka = new Bazooka();
			IWeapon pistol = new Pistol();

			Enemy enemyAWithBazooka = new EnemyA(mockPathFinder, bazooka, player, 50, mockPosition, null, enemyState.GetState("Moving"), mockMap);
			Enemy enemyBWithPistol = new EnemyB(mockPathFinder, pistol, player, 50, mockPosition, null, enemyState.GetState("Moving"), mockMap);

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

		private static void StateExample()
		{
			Console.WriteLine("State Example:");
			var mockPosition = Vector2.Zero;
			int mapSize = 32;
			var mockMap = new Map(mapSize, mapSize);
			IPathFinding pathfindingAdapter = new PathFindingAdapter(mockMap);
			var weapon = new Shotgun();
			var mockPlayer = new Player1 { LifePoints = 100 };
			var enemyState = new EnemyStateFactory();

			var enemy = new EnemyA(pathfindingAdapter, weapon, mockPlayer, 50, mockPosition, null, enemyState.GetState("Moving"), mockMap);
			enemy.DoAction();
			enemy.CurrentState = enemyState.GetState("Shooting");
			enemy.DoAction();
		}

		private static void ChainOfResponsibilityExample()
		{
			Console.WriteLine("Chain of Responsibility Example:");
			var mockPosition = Vector2.Zero;
			int mapSize = 32;
			var mockMap = new Map(mapSize, mapSize);
			IPathFinding pathfindingAdapter = new PathFindingAdapter(mockMap);
			var weapon = new Shotgun();
			var mockPlayer = new Player1 { LifePoints = 100 };
			var enemyState = new EnemyStateFactory();

			var grandparentEnemy = new EnemyA(pathfindingAdapter, weapon, mockPlayer, 100, mockPosition, null, enemyState.GetState("Moving"), mockMap);
			var parentEnemy = new EnemyB(pathfindingAdapter, weapon, mockPlayer, 100, mockPosition, null, enemyState.GetState("Moving"), mockMap);
			var childEnemy = new EnemyA(pathfindingAdapter, weapon, mockPlayer, 100, mockPosition, null, enemyState.GetState("Moving"), mockMap);

			parentEnemy.SetParentEnemy(grandparentEnemy);
			childEnemy.SetParentEnemy(parentEnemy);

			Console.WriteLine("Life points before child takes damage:");
			Console.WriteLine($"Grandparent: {grandparentEnemy.LifePoints}");
			Console.WriteLine($"Parent: {parentEnemy.LifePoints}");
			Console.WriteLine($"Child: {childEnemy.LifePoints}");

			childEnemy.TakeDamage(100);

			Console.WriteLine("Life points after child takes damage:");
			Console.WriteLine($"Grandparent: {grandparentEnemy.LifePoints}");
			Console.WriteLine($"Parent: {parentEnemy.LifePoints}");
			Console.WriteLine($"Child: {childEnemy.LifePoints}");
		}

		private static void MediatorExample()
		{
			Console.WriteLine("Mediator Example:");

			var enemyState = new EnemyStateFactory();
			var mapWidthAndHeight = 16;
			var mockPosition = Vector2.Zero;
            var mockMap = new Map(mapWidthAndHeight, mapWidthAndHeight);
			var mockPlayer = new Player1 { LifePoints = 100 };
			var mapObjects = new List<IMapObject>
			{
				new EnemyA(null, null, mockPlayer, 100, mockPosition, null, enemyState.GetState("Moving"), mockMap),
				new EnemyB(null, null, mockPlayer, 100, mockPosition, null, enemyState.GetState("Moving"), mockMap),
				new EnemyA(null, null, mockPlayer, 100, mockPosition, null, enemyState.GetState("Moving"), mockMap),
				new EnemyB(null, null, mockPlayer, 100, mockPosition, null, enemyState.GetState("Moving"), mockMap),
				new EnemyA(null, null, mockPlayer, 100, mockPosition, null, enemyState.GetState("Moving"), mockMap),
				mockPlayer,
				new Wall()
			};

			foreach (var mapObject in mapObjects)
			{
				mockMap.AddMapObject(mapObject);
			}

		    var newEnemy = new EnemyA(null, null, mockPlayer, 100, mockPosition, null, enemyState.GetState("Moving"), mockMap);
		    Logger.Instance.Info("All enemies received a message that an enemy spawned, so their base damages increase");
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
            CompositeExample();
            VisitorExample();
            StateExample();
            ChainOfResponsibilityExample();
            MediatorExample();

            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
