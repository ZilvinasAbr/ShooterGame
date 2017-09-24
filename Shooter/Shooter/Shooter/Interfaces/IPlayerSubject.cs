namespace Shooter.Interfaces
{
    interface IPlayerSubject
    {
        void AttachObserver(IEnemyObserver enemy);
        void DetachObserver(IEnemyObserver enemy);
        void Notify();
    }
}
