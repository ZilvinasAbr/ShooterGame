namespace Shooter.PatternClasses
{
	public class Memento
	{
		public float XCord { get; set; }
		public float YCord { get; set; }

		public Memento(float XCord, float YCord)
		{
			this.XCord = XCord;
			this.YCord = YCord;
		}
	}
}
