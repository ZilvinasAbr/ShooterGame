using Shooter.Classes.Enemies;

namespace Shooter.Classes
{
    public class IdleState : IActionState
    {
        public void DoAction(Enemy enemy)
        {
            enemy.Idle();
        }
    }
}
