using Enemy;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Turret.Weapon
{
    public class EnemySearch
    {
        // список который нельзя изменять только считывать
        private IReadOnlyList<EnemyData> m_EnemyDatas;

        // конструктор
        public EnemySearch(IReadOnlyList<EnemyData> enemyDatas)
        {
            m_EnemyDatas = enemyDatas;
        }

        // метод поиска который допустимо может быть null
        [CanBeNull]
        public EnemyData GetClosesEnemy (Vector3 center, float maxDistance)
        {
            float maxSqrDistance = maxDistance * maxDistance;

            float minSqrDistance = float.MaxValue;
            EnemyData closesEnemy = null;

            foreach (EnemyData enemyData in m_EnemyDatas)
            {
                float sqrDistance = (enemyData.View.transform.position - center).sqrMagnitude;
                if (sqrDistance < maxDistance)
                {
                    continue;
                }

                if (sqrDistance < minSqrDistance)
                {
                    minSqrDistance = sqrDistance;
                    closesEnemy = enemyData;
                }
            }

            return closesEnemy;
        }
    }
}
