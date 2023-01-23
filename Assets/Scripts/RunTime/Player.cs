using Enemy;
using Field;
using System.Collections.Generic;
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

        //пустой конструктор
        public Player()
        {
            GridHolder = Object.FindObjectOfType<GridHolder>();
            GridHolder.CreateGrid();

            Grid = GridHolder.Grid;
        }

        public void EnemySpawned(EnemyData data)
        {
            m_EnemyDatas.Add(data);
        }
    }
}
