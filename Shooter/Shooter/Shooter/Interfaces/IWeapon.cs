using Shooter.Classes.Weapons;

namespace Shooter.Interfaces
{
    public interface IWeapon
    {
        void Shoot(double baseDamage);
        Weapon Clone();
    }
}
