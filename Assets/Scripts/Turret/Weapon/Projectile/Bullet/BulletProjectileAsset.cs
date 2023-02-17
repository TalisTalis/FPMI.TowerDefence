using Assets;
using Assets.Scripts.Utils.Pooling;
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
            BulletProjectile projectile = (BulletProjectile)GameObjectPool.InstatiatePooled(m_BulletPrefab,
                origin,
                Quaternion.LookRotation(originForward, Vector3.up));

            projectile.SetAsset(this);
            return projectile;
        }
    }
}
