using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shooter.Classes;
using System;
using Shooter.Classes.Enemies;
using Shooter.Classes.Weapons;
using Shooter.Enums;
using Shooter.Interfaces;
using Shooter.PatternClasses;
using Shooter.Utils;

namespace Shooter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        readonly GraphicsDeviceManager _graphics;
		private Dictionary<string, Texture2D> _weaponTextures;
        private SpriteBatch _spriteBatch;
        private Texture2D _backgroundTexture;
        private Texture2D _playerTexture;
        private Texture2D _enemyATexture;
		private Texture2D _enemyBTexture;
        private Texture2D _bossTexture;
        private Texture2D _wallTexture;
        private KeyboardState _previousState;
        private IList<Enemy> _enemies;
        private IList<Wall> _walls;
		private IList<Weapon> _weapons;
		private Map _map;
        private Player1 _player;
        private IPathFinding _pathFinder;
        private int i = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = GameSettings.TileSize * GameSettings.MapSize,
                PreferredBackBufferHeight = GameSettings.TileSize * GameSettings.MapSize
            };
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            _previousState = Keyboard.GetState();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
			// Create a new SpriteBatch, which can be used to draw textures.
			_weaponTextures = new Dictionary<string, Texture2D>();
			_spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            _backgroundTexture = Content.Load<Texture2D>("background");
            _playerTexture = Content.Load<Texture2D>("player");
            _enemyATexture = Content.Load<Texture2D>("enemyA");
            _enemyBTexture = Content.Load<Texture2D>("enemyB");
            _bossTexture = Content.Load<Texture2D>("boss");

			foreach (var weapon in Enum.GetValues(typeof(WeaponName)))
			{
				_weaponTextures.Add(weapon.ToString(), Content.Load<Texture2D>(weapon.ToString()));
			}

			_wallTexture = Content.Load<Texture2D>("wall");

            _player = new Player1(Vector2.Zero, _playerTexture);
            _map = new Map(GameSettings.MapSize, GameSettings.MapSize) {BackgroundTexture = _backgroundTexture};
            _map.AddMapObject(_player);
            _pathFinder = new PathFindingAdapter(_map);

			var enemyState = new EnemyStateFactory();

            var enemiesFactory = new EnemiesConcreteFactory();
            _enemies = new List<Enemy>
            {
                enemiesFactory.CreateEnemy(_pathFinder, EnemyType.Small, new Bazooka(), _player, 100, new Vector2(5*GameSettings.TileSize, 5*GameSettings.TileSize), _enemyATexture, enemyState.GetState("Moving"), _map),
                enemiesFactory.CreateEnemy(_pathFinder, EnemyType.Big, new Pistol(), _player, 100, new Vector2(3*GameSettings.TileSize, 5*GameSettings.TileSize), _enemyBTexture, enemyState.GetState("Moving"), _map),
                enemiesFactory.CreateEnemy(_pathFinder, EnemyType.Boss, new Pistol(), _player, 500, new Vector2(1 * GameSettings.TileSize, 1 * GameSettings.TileSize), _bossTexture, enemyState.GetState("Moving"), _map),
                enemiesFactory.CreateEnemy(_pathFinder, EnemyType.Boss, new Pistol(), _player, 250, new Vector2(1 * GameSettings.TileSize, 2 * GameSettings.TileSize), _bossTexture, enemyState.GetState("Moving"), _map)
            };

            Boss boss = (Boss)_enemies[2];
            boss.AddMinion(_enemies[0]);
            boss.AddMinion(_enemies[1]);
            boss.AddMinion(_enemies[3]);

            foreach (Enemy minion in boss.GetMinions())
                _map.AddMapObject(minion);

            var clonedEnemies = new List<Enemy>
            {
                _enemies[0].DeepCopy(),
                _enemies[0].DeepCopy(),
                _enemies[1].DeepCopy(),
                _enemies[1].DeepCopy()
            };

            clonedEnemies[0].Position = new Vector2(7 * GameSettings.TileSize, 5 * GameSettings.TileSize);
            clonedEnemies[1].Position = new Vector2(5 * GameSettings.TileSize, 9 * GameSettings.TileSize);
            clonedEnemies[2].Position = new Vector2(2 * GameSettings.TileSize, 4 * GameSettings.TileSize);
            clonedEnemies[3].Position = new Vector2(5 * GameSettings.TileSize, 1 * GameSettings.TileSize);

            _enemies.Add(clonedEnemies[0]);
            _enemies.Add(clonedEnemies[1]);
            _enemies.Add(clonedEnemies[2]);
            _enemies.Add(clonedEnemies[3]);

            Boss boss2 = (Boss)_enemies[3];
            boss2.AddMinion(_enemies[4]);

            _walls = new List<Wall>
            {
                new Wall{Position = new Vector2(10*GameSettings.TileSize, 10*GameSettings.TileSize), Texture = _wallTexture},
                new Wall{Position = new Vector2(11*GameSettings.TileSize, 10*GameSettings.TileSize), Texture = _wallTexture},
                new Wall{Position = new Vector2(12*GameSettings.TileSize, 10*GameSettings.TileSize), Texture = _wallTexture},
                new Wall{Position = new Vector2(13*GameSettings.TileSize, 10*GameSettings.TileSize), Texture = _wallTexture},
                new Wall{Position = new Vector2(14*GameSettings.TileSize, 10*GameSettings.TileSize), Texture = _wallTexture},
                new Wall{Position = new Vector2(15*GameSettings.TileSize, 10*GameSettings.TileSize), Texture = _wallTexture}
            };
			_weapons = new List<Weapon>();

            foreach (var enemy in _enemies)
            {
                _map.AddMapObject(enemy);
            }
            foreach (var wall in _walls)
            {
                _map.AddMapObject(wall);
            }
			foreach (var weapon in _weapons)
			{
				_map.AddMapObject(weapon);
			}
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			// TODO: Add your update logic here
			UpdateWeapon(gameTime);
            UpdatePlayer(gameTime);
            i++;
            if(i > 200)
            {
                Boss boss = (Boss)_enemies[2];
                boss.Accept(new EnemyKiller());
            }
            RemoveDeadEnemies();

            base.Update(gameTime);
        }

		protected void UpdateWeapon(GameTime gameTime)
		{
			var val = StaticRandom.Instance.Next(0, 1000);

			if (val == 0)
			{
				Weapon weapon = new NullObjectWeapon();

				var factory = WeaponFactory.CreateFactory((WeaponType)StaticRandom.Instance.Next(0, 2));
			
				switch (factory)
				{
					case HeavyWeaponFactory h:
						var num = StaticRandom.Instance.Next(0, 2);
						weapon = factory.CreateWeapon((WeaponName)num);
						break;
					case LightWeaponFactory l:
						var num2 = StaticRandom.Instance.Next(2, 4);
						weapon = factory.CreateWeapon((WeaponName)num2);
						break;
				}

				_weapons.Add(weapon);
				weapon.Texture = _weaponTextures[weapon.Name];
				_map.MapObjects.Add(weapon);
			}
		}

        protected void UpdatePlayer(GameTime gameTime)
        {
            _player.Update(gameTime);

            var position = _player.Position;

            var keyboardState = Keyboard.GetState();

			if (keyboardState.IsKeyDown(Keys.Space))
			{
				var moves = MoveMemory.MovesHistory;
				if (moves.Count > 4)
				{
					_player.RestoreMemento(moves[moves.Count - 4]);
					MoveMemory.MovesHistory.Clear();
				}
			}

			_player.Move(keyboardState, _previousState);

            _previousState = keyboardState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _map.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void RemoveDeadEnemies()
        {
            foreach(Enemy enemy in _enemies)
            {
                if(!enemy.IsAlive())
                {
                    _map.MapObjects.Remove(enemy);
                }
            }
        }
    }
}
