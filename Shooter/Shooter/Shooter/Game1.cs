using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shooter.Classes;
using Shooter.Interfaces;

namespace Shooter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        const int TileSize = 32;
        readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _backgroundTexture;
        private Texture2D _playerTexture;
        private Texture2D _enemyATexture;
        private Texture2D _enemyBTexture;
        private Texture2D _wallTexture;
        private KeyboardState _previousState;
        private IList<Enemy> _enemies;
        private IList<Wall> _walls;

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
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            _backgroundTexture = Content.Load<Texture2D>("background");
            _playerTexture = Content.Load<Texture2D>("player");
            _enemyATexture = Content.Load<Texture2D>("enemyA");
            _enemyBTexture = Content.Load<Texture2D>("enemyB");
            _wallTexture = Content.Load<Texture2D>("wall");

            _player = new Player1(Vector2.Zero, _playerTexture);
            _map = new Map(16, 16) {BackgroundTexture = _backgroundTexture};
            _map.MapObjects.Add(_player);
            _enemies = new List<Enemy>
            {
                new EnemyA(new Bazooka(), _player, 100, new Vector2(5*TileSize, 5*TileSize)){Texture = _enemyATexture},
                new EnemyB(new Pistol(), _player, 100, new Vector2(6*TileSize, 5*TileSize)){Texture = _enemyBTexture}
            };
            _walls = new List<Wall>
            {
                new Wall{Position = new Vector2(10*TileSize, 10*TileSize), Texture = _wallTexture},
                new Wall{Position = new Vector2(11*TileSize, 10*TileSize), Texture = _wallTexture}
            };
            foreach (var enemy in _enemies)
            {
                _map.MapObjects.Add(enemy);
            }
            foreach (var wall in _walls)
            {
                _map.MapObjects.Add(wall);
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
            UpdatePlayer(gameTime);

            base.Update(gameTime);
        }

        protected void UpdatePlayer(GameTime gameTime)
        {
            _player.Update(gameTime);

            var position = _player.Position;

            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.W) && !_previousState.IsKeyDown(Keys.W))
            {
                _player.Position = new Vector2(position.X, position.Y - TileSize);
            }

            if (keyboardState.IsKeyDown(Keys.S) && !_previousState.IsKeyDown(Keys.S))
            {
                _player.Position = new Vector2(position.X, position.Y + TileSize);

            }

            if (keyboardState.IsKeyDown(Keys.A) && !_previousState.IsKeyDown(Keys.A))
            {
                _player.Position = new Vector2(position.X - TileSize, position.Y);

            }

            if (keyboardState.IsKeyDown(Keys.D) && !_previousState.IsKeyDown(Keys.D))
            {
                _player.Position = new Vector2(position.X + TileSize, position.Y);
            }

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
