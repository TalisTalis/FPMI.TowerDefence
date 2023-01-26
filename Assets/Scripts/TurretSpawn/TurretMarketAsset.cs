using Turret;
using UnityEngine;

namespace TurretSpawn
{
    [CreateAssetMenu(menuName = "Assets/Turret Market Asset", fileName = "Turret Market Asset")]
    public class TurretMarketAsset : ScriptableObject
    {
        // список башень
        public TurretAsset[] TurretAssets;
    }
}
