using Enemy;
using UnityEngine;

namespace Projectile
{
    public abstract class ProjectileAssetBase : ScriptableObject
    {
        public abstract ProjectileBase CreateProjectile(Vector3 origin, Vector3 originForward, EnemyData enemyData);
    }
}
