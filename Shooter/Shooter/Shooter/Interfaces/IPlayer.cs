using Shooter.Classes;

namespace Shooter.Interfaces
{
    public interface IPlayer : IMapObject, IPlayerSubject
    {
        int LifePoints { get; set; }
    }
}
