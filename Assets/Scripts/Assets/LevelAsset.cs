using EnemySpawn;
using TurretSpawn;
using UnityEditor;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(menuName = "Assets/Level Asset", fileName = "LevelAsset")]
    public class LevelAsset : ScriptableObject
    {
        public SceneAsset SceneAsset;
        public SpawnWavesAsset SpawnWavesAsset;
        public TurretMarketAsset TurretMarketAsset;
    }
}
