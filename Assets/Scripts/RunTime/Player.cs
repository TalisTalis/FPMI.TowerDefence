using Assets.Scripts.Turret.Weapon;
using Enemy;
using Field;
using System.Collections.Generic;
using TurretSpawn;
using UnityEngine;

namespace RunTime
{
    public class Player
    {
        private List<EnemyData> m_EnemyDatas = new List<EnemyData>();

        // нельзя модифицировать список
        public IReadOnlyList<EnemyData> EnemyDatas => m_EnemyDatas;

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
        }

        public void EnemySpawned(EnemyData data)
        {
            m_EnemyDatas.Add(data);
        }
    }
}
