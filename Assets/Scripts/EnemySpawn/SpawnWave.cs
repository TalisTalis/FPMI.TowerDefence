using Assets;

namespace EnemySpawn
{
    [System.Serializable]
    public class SpawnWave
    {
        public EnemyAsset EnemyAsset;
        // спавн нескольких врагов
        public int Count;
        // время между спавном
        public float TimeBetweenSpawns;

        public float TimeBeforeStartWave;
    }
}
