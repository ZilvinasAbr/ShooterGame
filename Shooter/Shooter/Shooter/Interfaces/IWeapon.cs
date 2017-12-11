using Shooter.Classes.Weapons;

namespace Shooter.Interfaces
{
    public interface IWeapon
    {
        void PrepareToShoot(double baseDamage);
        Weapon Clone();
    }
}
