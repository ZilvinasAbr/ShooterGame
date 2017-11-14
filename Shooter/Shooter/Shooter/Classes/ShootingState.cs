using System;

namespace Shooter.Classes
{
    class ShootingState : IActionState
    {
        public void DoAction(Enemy enemy)
        {
            Console.WriteLine("Shoots");
            enemy.Attack();
        }
    }
}
