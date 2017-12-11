using Shooter.Classes;
using System.Collections.Generic;

namespace Shooter.PatternClasses
{
	public class EnemyStateFactory
	{
		private Dictionary<string, IActionState> _states = new Dictionary<string, IActionState>();

		public IActionState GetState(string state)
		{
			IActionState actionState = null;

			if (_states.ContainsKey(state))
			{
				actionState = _states[state];
			}
			else
			{
				switch (state)
				{
					case "Moving":
						actionState = new MovingState();
						break;
					case "Idle":
						actionState = new IdleState();
						break;
					case "Shooting":
						actionState = new ShootingState();
						break;
				}
				_states.Add(state, actionState);
			}

			return actionState;
		}
	}
}
