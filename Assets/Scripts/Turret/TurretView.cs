using UnityEngine;

namespace Turret
{
    public class TurretView : MonoBehaviour
    {
        [SerializeField]
        private Transform m_ProjectileOrigin;

        // ссылка на аниматор
        [SerializeField]
        private Animator m_Animator;

        // откуда стреляет башня
        [SerializeField]
        private Transform m_Tower;

        private TurretData m_Data;
        private static int ShotAnimationIndex => Animator.StringToHash("Shot");

        public TurretData Data => m_Data;
        public Transform ProjectileOrigin => m_ProjectileOrigin;

        public void AttachData(TurretData turretData)
        {
            m_Data = turretData;
            transform.position = m_Data.Node.Position;
        }

        // метод для вращения башни
        public void TowerLookAt(Vector3 point)
        {
            // чтобы башня не скакала вверх вниз за таргетом
            point.y = m_Tower.position.y;
            m_Tower.LookAt(point);
        }

        public void AnimateShot()
        {
            // имя триггера который настроен ранее
            m_Animator.SetTrigger(ShotAnimationIndex);
        }
    }
}
