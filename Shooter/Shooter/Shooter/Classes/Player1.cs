﻿using System;
using Shooter.Interfaces;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shooter.PatternClasses;
using Shooter.Utils;

namespace Shooter.Classes
{
    public class Player1 : IPlayer
    {
        private readonly IList<IEnemyObserver> _enemyObservers;
        public Texture2D Texture { get; set; }
        public IMap Map { get; set; }
        public Vector2 Position { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Receive(string message)
        {
            Console.WriteLine($"Received a message: {message}");
        }

        public void Send(string message)
        {
            Map.BroadcastToEnemies(message, this);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public double LifePoints { get; set; }

        public Player1()
        {
            _enemyObservers = new List<IEnemyObserver>();
        }

        public Player1(Vector2 position, Texture2D texture)
        {
            Position = position;
            Texture = texture;
            _enemyObservers = new List<IEnemyObserver>();
        }

        public void AttachObserver(IEnemyObserver observer)
        {
            _enemyObservers.Add(observer);
        }

        public void DetachObserver(IEnemyObserver observer)
        {
            _enemyObservers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var enemyObserver in _enemyObservers)
            {
                enemyObserver.UpdateObserver();
            }
        }

		public void Move(KeyboardState keyboardState, KeyboardState previousState)
		{
			ICommand cmd = null;

			if (keyboardState.IsKeyDown(Keys.W) && !previousState.IsKeyDown(Keys.W))
			{
				cmd = new MoveForward(this);
			}
			if (keyboardState.IsKeyDown(Keys.S) && !previousState.IsKeyDown(Keys.S))
			{
				cmd = new MoveBackward(this);
			}
			if (keyboardState.IsKeyDown(Keys.A) && !previousState.IsKeyDown(Keys.A))
			{
				cmd = new MoveLeft(this);
			}
			if (keyboardState.IsKeyDown(Keys.D) && !previousState.IsKeyDown(Keys.D))
			{
				cmd = new MoveRight(this);
			}

			if (cmd != null)
			{
				MoveMemory.SaveState(SaveMemento());
				cmd.Execute();
                Notify();
			}
		}

		public Memento SaveMemento()
		{
			return new Memento(Position.X, Position.Y);
		}

		// Restores memento
		public void RestoreMemento(Memento previousState)
		{
			Position = new Vector2(previousState.XCord + GameSettings.TileSize, previousState.YCord);
		}
	}
}
