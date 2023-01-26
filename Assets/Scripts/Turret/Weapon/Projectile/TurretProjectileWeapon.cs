using Enemy;
using RunTime;
using Turret;
using UnityEngine;
using Weapon;

namespace Projectile
{
    public class TurretProjectileWeapon : ITurretWeapon
    {
        private TurretProjectileWeaponAsset m_Asset;
        // хранение башни
        private TurretView m_View;
        // время между выстрелами
        private float m_TimeBetweenShots;
        // сохранение максимального расстояния
        private float m_MaxDistance;

        // хранение времени с последнего выстрела
        private float m_LastShotTime = 0f;

        public TurretProjectileWeapon(TurretProjectileWeaponAsset asset, TurretView view)
        {
            m_Asset = asset;
            m_View = view;
            m_TimeBetweenShots = 1f / m_Asset.RateOfFire;
            m_MaxDistance = m_Asset.MaxDistance;
        }
        public void TickShoot()
        {
            // сколько времени прошло с последнего выстрела
            float passedTime = Time.time - m_LastShotTime;

            if (passedTime < m_TimeBetweenShots)
            {
                return;
            }

            EnemyData closesEnemyData = 
                Game.Player.EnemySearch.GetClosesEnemy(m_View.transform.position, m_MaxDistance);
            if (closesEnemyData == null)
            {
                return;
            }

            Shoot(closesEnemyData);

            m_LastShotTime = Time.time;
        }

        private void Shoot(EnemyData enemyData)
        {
            m_Asset.ProjectileAsset.CreateProjectile(m_View.ProjectileOrigin.position, m_View.ProjectileOrigin.forward, enemyData);
        }
    }
}
