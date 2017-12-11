using Shooter.Classes.Weapons;

namespace Shooter.PatternClasses
{
    public class NullObjectWeapon : Weapon
    {
        protected override bool IsWeaponReloadable()
        {
            return false;
        }

        protected override void Reload()
        {
        }

        protected override bool ShouldReload()
        {
            return false;
        }

        protected override void Shoot(double baseDamage)
        {

        }
    }
}
