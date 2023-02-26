using UnityEngine;
using Weapon;

namespace Turret
{
    [CreateAssetMenu(menuName = "Assets/Turret Asset", fileName = "TurretAsset")]
    public class TurretAsset : ScriptableObject
    {
        public Sprite Sprite;

        public string Description;
        
        public TurretView ViewPrefab;

        public TurretWeaponAssetBase WeaponAsset;

        public int Price;
    }
}
