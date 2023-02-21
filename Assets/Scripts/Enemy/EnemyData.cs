using Assets;
using UnityEngine;

namespace Assets
{
    public class EnemyData
    {
        // ссылка на вью
        private EnemyView m_View;
        private EnemyAsset m_Asset;
        private float m_Health;

        public bool IsDead => m_Health <= 0;

        public EnemyView View => m_View;
        public EnemyAsset Asset => m_Asset;

        // конструктор
        public EnemyData(EnemyAsset asset)
        {
            m_Asset = asset;
            m_Health = asset.StartHealth;
        }

        public void AttachView(EnemyView view)
        {
            m_View = view;
            m_View.AttachData(this);
        }

        public void GetDamage(float damage)
        {
            if (IsDead)
            {
                return;
            }
            m_Health -= damage;
        }

        public void Die()
        {
            m_View.Die();
        }

        public void ReachedTarget()
        {
            m_Health = 0;
            View.ReachTarget();
        }
    }
}
