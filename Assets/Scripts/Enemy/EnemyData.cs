using Enemy;
using UnityEngine;

namespace Enemy
{
    public class EnemyData
    {
        // ссылка на вью
        private EnemyView m_View;
        private int m_Health;

        public EnemyView View => m_View;

        // конструктор
        public EnemyData(EnemyAsset asset)
        {
            m_Health = asset.StartHealth;
        }

        public void AttachView(EnemyView view)
        {
            m_View = view;
            m_View.AttachData(this);
        }

        public void GetDamage(int damage)
        {
            m_Health -= damage;

            if (m_Health < 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Die!");
        }
    }
}
