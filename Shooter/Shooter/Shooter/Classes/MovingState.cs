using System;

namespace Shooter.Classes
{
    public class MovingState : IActionState
    {
        public void DoAction(Enemy enemy)
        {
            Console.WriteLine("Moves");
            enemy.MoveToPlayer();
        }
    }
}
