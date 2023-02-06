using Enemy;
using Projectile;
using UnityEngine;

namespace Bullet
{
    [CreateAssetMenu(menuName = "Assets/Bullet Projectile Asset", fileName = "BulletProjectileAsset")]
    public class BulletProjectileAsset : ProjectileAssetBase
    {
        [SerializeField]
        private BulletProjectile m_BulletPrefab;
        public override IProjectile CreateProjectile(Vector3 origin, Vector3 originForward, EnemyData enemyData)
        {
            return Instantiate(m_BulletPrefab,
                origin,
                Quaternion.LookRotation(originForward, Vector3.up));
        }
    }
}
