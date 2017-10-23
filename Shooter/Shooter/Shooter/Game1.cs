using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shooter.Classes;
using System;
using Shooter.Enums;
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
        private Texture2D _wallTexture;
        private KeyboardState _previousState;
        private IList<Enemy> _enemies;
        private IList<Wall> _walls;
		private IList<Weapon> _weapons;
		private Map _map;
        private Player1 _player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 512,
                PreferredBackBufferHeight = 512
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

			foreach (var weapon in Enum.GetValues(typeof(WeaponName)))
			{
				_weaponTextures.Add(weapon.ToString(), Content.Load<Texture2D>(weapon.ToString()));
			}

			_wallTexture = Content.Load<Texture2D>("wall");

            _player = new Player1(Vector2.Zero, _playerTexture);
            _map = new Map(GameSettings.MapSize, GameSettings.MapSize) {BackgroundTexture = _backgroundTexture};
            _map.MapObjects.Add(_player);
            var enemiesFactory = new EnemiesConcreteFactory();
            _enemies = new List<Enemy>
            {

                new EnemyA(new Bazooka(), _player, 100, new Vector2(5*GameSettings.TilesSize, 5*GameSettings.TilesSize)){Texture = _enemyATexture},
                new EnemyB(new Pistol(), _player, 100, new Vector2(6*GameSettings.TilesSize, 5*GameSettings.TilesSize)){Texture = _enemyBTexture}
            };
            _walls = new List<Wall>
            {
                new Wall{Position = new Vector2(10*GameSettings.TilesSize, 10*GameSettings.TilesSize), Texture = _wallTexture},
                new Wall{Position = new Vector2(11*GameSettings.TilesSize, 10*GameSettings.TilesSize), Texture = _wallTexture}
            };
			_weapons = new List<Weapon>
			{
				//new Bazooka {Position = new Vector2(7*GameSettings.TilesSize, 7*GameSettings.TilesSize), Texture = _bazookaTexture}
			};

            foreach (var enemy in _enemies)
            {
                _map.MapObjects.Add(enemy);
            }
            foreach (var wall in _walls)
            {
                _map.MapObjects.Add(wall);
            }
			foreach (var weapon in _weapons)
			{
				_map.MapObjects.Add(weapon);
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

            base.Update(gameTime);
        }

		protected void UpdateWeapon(GameTime gameTime)
		{
			var val = StaticRandom.Instance.Next(0, 50);

			if (val == 0)
			{
				Weapon weapon = null;

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
				weapon.Texture = _weaponTextures[weapon.TextureName];
				_map.MapObjects.Add(weapon);
			}
		}

        protected void UpdatePlayer(GameTime gameTime)
        {
            _player.Update(gameTime);

            var position = _player.Position;

            var keyboardState = Keyboard.GetState();

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
    }
}
