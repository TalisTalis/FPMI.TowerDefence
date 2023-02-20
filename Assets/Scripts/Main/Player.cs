using Weapon;
using Assets;
using Field;
using System.Collections.Generic;
using Turret;
using TurretSpawn;
using UnityEngine;
using RunTime;

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

        public Player()
        {
            GridHolder = Object.FindObjectOfType<GridHolder>();
            GridHolder.CreateGrid();

            Grid = GridHolder.Grid;

            // магазин башень на конкретном уровне
            TurretMarket = new TurretMarket(Game.CurrentLevel.TurretMarketAsset);

            EnemySearch = new EnemySearch(m_EnemyDatas);
            //Debug.Log("search");
        }

        public void EnemySpawned(EnemyData data)
        {
            m_EnemyDatas.Add(data);
        }

        public void EnemyDied(EnemyData data)
        {
            m_EnemyDatas.Remove(data);
        }

        public void LastWaveSpawned()
        {
            m_AllWavesAreSpawned = true;
        }

        public void TurretSpawned(TurretData data)
        {
            m_TurretDatas.Add(data);
        }

        private void GameWon()
        {
            Game.StopPlayer();
            Debug.Log("Victory!");
        }

        public void CheckForWin()
        {
            if (m_AllWavesAreSpawned && m_EnemyDatas.Count == 0)
            {
                GameWon();
            }
        }
    }
}
