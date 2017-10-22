using Microsoft.Xna.Framework;
using Shooter.Interfaces;

namespace Shooter.Classes
{
	public class MoveForward : ICommand
	{
		private readonly Player1 _player;

		public MoveForward(Player1 player)
		{
			_player = player;
		}

		public void Execute()
		{
			var position = _player.Position;
			_player.Position = new Vector2(position.X, position.Y - GameSettings.TilesSize);
		}
	}
}
