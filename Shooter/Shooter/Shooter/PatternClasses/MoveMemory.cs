using System.Collections.Generic;

namespace Shooter.PatternClasses
{
	public static class MoveMemory
	{
		public static List<Memento> MovesHistory = new List<Memento>();

		public static void SaveState(Memento memento)
		{
			MovesHistory.Add(memento);
		}
	}
}
