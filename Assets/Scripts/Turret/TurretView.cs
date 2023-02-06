using UnityEngine;

namespace Turret
{
    public class TurretView : MonoBehaviour
    {
        [SerializeField]
        private Transform m_ProjectileOrigin;

        // откуда стреляет башня
        [SerializeField]
        private Transform m_Tower;

        private TurretData m_Data;

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
    }
}
