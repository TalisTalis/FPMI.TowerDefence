using Enemy;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Assets/Enemy Asset", fileName = "Enemy Asset")]
    public class EnemyAsset : ScriptableObject
    {
        // внешнее представление
        public EnemyView ViewPrefab;

        // характеристики врагов
        public int StartHealth;
    }
}
