using Weapon;
using Assets;
using Field;
using System.Collections.Generic;
using Turret;
using TurretSpawn;
using UnityEngine;
using RunTime;
using System;

namespace Assets.Scripts.Main
{
    public class Player
    {
        private List<EnemyData> m_EnemyDatas = new List<EnemyData>();
        // нельзя модифицировать список врагов
        public IReadOnlyList<EnemyData> EnemyDatas => m_EnemyDatas;

        // список оружия
        private List<TurretData> m_TurretDatas = new List<TurretData>();
        public IReadOnlyList<TurretData> TurretDatas => m_TurretDatas;

        public readonly GridHolder GridHolder;
        public readonly Field.Grid Grid;
        public readonly TurretMarket TurretMarket;
        public readonly EnemySearch EnemySearch;

        private bool m_AllWavesAreSpawned = false;
        private int m_Health;

        public int Health => m_Health;
        // событие которое можно вызвать и передать в него данные указанного типа
        // а другие могут на это событие подписаться и будет вызываться указанный метод
        public event Action<int> HealthChanged;

        public Player()
        {
            GridHolder = UnityEngine.Object.FindObjectOfType<GridHolder>();
            GridHolder.CreateGrid();

            Grid = GridHolder.Grid;

            // магазин башень на конкретном уровне
            TurretMarket = new TurretMarket();

            EnemySearch = new EnemySearch(m_EnemyDatas);
            m_Health = Game.CurrentLevel.StartHealth;
        }

        public void EnemySpawned(EnemyData data)
        {
            m_EnemyDatas.Add(data);
        }

        public void EnemyDied(EnemyData data)
        {
            m_EnemyDatas.Remove(data);
        }

        public void EnemyReachTarget(EnemyData data)
        {
            m_EnemyDatas.Remove(data);
        }

        public void LastWaveSpawned()
        {
            m_AllWavesAreSpawned = true;
        }

        public void ApplyDamage(int damage)
        {
            m_Health -= damage;
            if (m_Health < 0)
            {
                m_Health = 0;
            }
            HealthChanged?.Invoke(m_Health); // если null то всё что после точки исполнять не нужно
        }

        public void TurretSpawned(TurretData data)
        {
            m_TurretDatas.Add(data);
        }
        
        public void CheckForWin()
        {
            if (m_AllWavesAreSpawned && m_EnemyDatas.Count == 0)
            {
                GameWon();
            }
        }

        private void GameWon()
        {
            Game.StopPlayer();
            Debug.Log("Victory!");
        }

        public void CheckForLose()
        {
            if (m_Health <= 0)
            {
                GameLost();
            }
        }

        private void GameLost()
        {
            Game.StopPlayer();
            Debug.Log("Lose!");
        }

        public void Pause()
        {
            Time.timeScale = 0f;
        }

        public void UnPause()
        {
            Time.timeScale = 1f;
        }
    }
}
