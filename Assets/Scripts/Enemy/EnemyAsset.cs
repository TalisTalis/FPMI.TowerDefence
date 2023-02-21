using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Assets/Enemy Asset", fileName = "Enemy Asset")]
    public class EnemyAsset : ScriptableObject
    {
        // характеристики врагов
        public float StartHealth;
        public float Speed;
        // внешнее представление
        public EnemyView ViewPrefab;

        public int Damage;
        public int Reward;
    }
}
