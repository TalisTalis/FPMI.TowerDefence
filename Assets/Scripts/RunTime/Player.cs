using Weapon;
using Enemy;
using Field;
using System.Collections.Generic;
using Turret;
using TurretSpawn;
using UnityEngine;

namespace RunTime
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

        //пустой конструктор
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

        public void TurretSpawned(TurretData data)
        {
            m_TurretDatas.Add(data);
        }
    }
}
