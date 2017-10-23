namespace Shooter.Interfaces
{
    public interface IPlayerSubject
    {
        void AttachObserver(IEnemyObserver enemy);
        void DetachObserver(IEnemyObserver enemy);
        void Notify();
    }
}
