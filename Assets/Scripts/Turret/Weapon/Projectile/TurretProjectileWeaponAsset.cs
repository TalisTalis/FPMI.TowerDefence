using Turret;
using UnityEngine;
using Weapon;

namespace Projectile
{
    [CreateAssetMenu(menuName = "Assets/Turret Projectile Weapon Asset", fileName = "TurretProjectileWeaponAsset")]
    public class TurretProjectileWeaponAsset : TurretWeaponAssetBase
    {
        public float RateOfFire;
        public float MaxDistance;

        public ProjectileAssetBase ProjectileAsset;

        public override ITurretWeapon GetWeapon(TurretView view)
        {
            return new TurretProjectileWeapon(this, view);
        }
    }
}
