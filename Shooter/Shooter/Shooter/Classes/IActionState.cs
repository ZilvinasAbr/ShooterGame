using Shooter.Classes.Enemies;

namespace Shooter.Classes
{
    public interface IActionState
    {
        void DoAction(Enemy enemy);
    }
}
