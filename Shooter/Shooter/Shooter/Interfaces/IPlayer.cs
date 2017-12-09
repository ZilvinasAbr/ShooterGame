using Shooter.Classes;

namespace Shooter.Interfaces
{
    public interface IPlayer : IMapObject, IPlayerSubject
    {
        double LifePoints { get; set; }
    }
}
