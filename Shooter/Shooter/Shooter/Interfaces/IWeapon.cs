using Shooter.Classes;

namespace Shooter.Interfaces
{
    public interface IWeapon
    {
        void Shoot(double baseDamage);
        Weapon Clone();
    }
}
