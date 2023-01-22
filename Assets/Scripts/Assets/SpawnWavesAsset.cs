using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Assets/Spawn Waves Asset", fileName = "Spawn Waves Asset")]
    public class SpawnWavesAsset : ScriptableObject
    {
        public EnemyAsset EnemyAsset;
        // спавн нескольких врагов
        public int Count;
        // время между спавном
        public float TimeBetweenSpawns;
    }
}
