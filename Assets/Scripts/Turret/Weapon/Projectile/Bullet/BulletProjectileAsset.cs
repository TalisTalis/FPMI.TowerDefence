using Assets;
using Projectile;
using UnityEngine;

namespace Bullet
{
    [CreateAssetMenu(menuName = "Assets/Bullet Projectile Asset", fileName = "BulletProjectileAsset")]
    public class BulletProjectileAsset : ProjectileAssetBase
    {
        [SerializeField]
        private BulletProjectile m_BulletPrefab;

        public float Speed;
        public float Damage;
        public override IProjectile CreateProjectile(Vector3 origin, Vector3 originForward, EnemyData enemyData)
        {
            BulletProjectile projectile = Instantiate(m_BulletPrefab,
                origin,
                Quaternion.LookRotation(originForward, Vector3.up));

            projectile.SetAsset(this);
            return projectile;
        }
    }
}
