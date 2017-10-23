using Microsoft.Xna.Framework;
using Shooter.Classes;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
	public class MoveRight : ICommand
	{
		private readonly Player1 _player;

		public MoveRight(Player1 player)
		{
			_player = player;
		}

		public void Execute()
		{
			var position = _player.Position;
			_player.Position = new Vector2(position.X + GameSettings.TilesSize, position.Y);
		}
	}
}
