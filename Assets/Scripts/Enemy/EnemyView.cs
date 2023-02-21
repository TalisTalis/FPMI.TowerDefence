using Field;
using System;
using UnityEngine;

namespace Assets
{
    public class EnemyView : MonoBehaviour
    {
        // ссылка на дату
        private EnemyData m_Data;
        private IMovementAgent m_MovementAgent;

        // свойство ридонли
        public EnemyData Data => m_Data;

        public IMovementAgent MovementAgent => m_MovementAgent;

        // метод который устанавливает дату
        public void AttachData(EnemyData data)
        {
            m_Data = data;
        }

        // метод который создает этого агента
        public void CreateMovementAgent(Field.Grid grid)
        {
            m_MovementAgent = new GridMovementAgent(m_Data.Asset.Speed, transform, grid);
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        internal void ReachTarget()
        {
            Destroy(gameObject);
        }
    }
}
