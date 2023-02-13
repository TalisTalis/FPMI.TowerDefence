using Projectile;
using Assets;
using UnityEngine;

namespace Projectile
{
    public abstract class ProjectileAssetBase : ScriptableObject
    {
        public abstract IProjectile CreateProjectile(Vector3 origin, Vector3 originForward, EnemyData enemyData);
    }
}
