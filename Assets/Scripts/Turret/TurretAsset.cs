using UnityEngine;
using Weapon;

namespace Turret
{
    [CreateAssetMenu(menuName = "Assets/Turret Asset", fileName = "TurretAsset")]
    public class TurretAsset : ScriptableObject
    {
        public TurretView ViewPrefab;

        public TurretWeaponAssetBase WeaponAsset;

        public int Price;
    }
}
