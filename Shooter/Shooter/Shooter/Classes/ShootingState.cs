using System;
using Shooter.Classes.Enemies;

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
