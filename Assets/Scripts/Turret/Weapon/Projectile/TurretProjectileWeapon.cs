using Enemy;
using JetBrains.Annotations;
using RunTime;
using System.Collections.Generic;
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
        // чтобы башня постоянно смотрела на таргет не смотря на тики
        [CanBeNull]
        private EnemyData m_ClosesEnemyData;

        private List<IProjectile> m_Projectiles = new List<IProjectile>();

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
            TickWeapon();
            TickTower();
            //Debug.Log("search"); 
            TickProjectiles();
        }

        private void TickWeapon()
        {
            // сколько времени прошло с последнего выстрела
            float passedTime = Time.time - m_LastShotTime;

            if (passedTime < m_TimeBetweenShots)
            {
                return;
            }
            //Debug.Log("search");

            m_ClosesEnemyData = Game.Player.EnemySearch.GetClosesEnemy(m_View.transform.position, m_MaxDistance);

            if (m_ClosesEnemyData == null)
            {
                //Debug.Log("search");
                return;
            }

            TickTower();

            Shoot(m_ClosesEnemyData);

            m_LastShotTime = Time.time;
        }

        // метод поворота башни
        private void TickTower()
        {
            if (m_ClosesEnemyData != null)
            {
                m_View.TowerLookAt(m_ClosesEnemyData.View.transform.position);
            }            
        }

        private void TickProjectiles()
        {
            for (int i = 0; i < m_Projectiles.Count; i++)
            {
                IProjectile projectile = m_Projectiles[i];
                projectile.TickApproaching();

                if (projectile.DidHit())
                {
                    projectile.DestroyProjectile();
                    //m_Projectiles.Remove(projectile);
                    m_Projectiles[i] = null;
                }
            }

            m_Projectiles.RemoveAll(projectile => projectile == null);
        }

        private void Shoot(EnemyData enemyData)
        {
            m_Projectiles.Add(m_Asset.ProjectileAsset.CreateProjectile(m_View.ProjectileOrigin.position, m_View.ProjectileOrigin.forward, enemyData));
        }
    }
}
