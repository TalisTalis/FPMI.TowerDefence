using Field;
using RunTime;
using Turret;
using UnityEngine;

namespace TurretSpawn
{
    public class TurretSpawnController : IController
    {
        private Field.Grid m_Grid;
        private TurretMarket m_Market;

        public TurretSpawnController(Field.Grid grid, TurretMarket market)
        {
            m_Grid = grid;
            m_Market = market;
        }

        public void OnStart()
        {

        }

        public void OnStop()
        {

        }

        public void Tick()
        {
            if (m_Grid.HasSelectedNode() && Input.GetMouseButtonDown(0))
            {
                Node selectedNode = m_Grid.GetSelectedNode();

                if (selectedNode.IsOccupied) /* || !m_Grid.CanOccupy(selectedNote) */
                {
                    return;
                }

                TurretAsset asset = m_Market.ChosenTurret;

                if (asset != null)
                {
                    m_Market.BuyTurret(asset);
                    SpawnTurret(asset, selectedNode);
                }
                else
                {
                    Debug.Log("Not enough money!");
                }

            }
        }

        // метод спавна башни в ноде
        public void SpawnTurret(TurretAsset asset, Node node)
        {
            TurretView view = Object.Instantiate(asset.ViewPrefab);

            TurretData data = new TurretData(asset, node);

            data.AttachView(view);

            // спавн туррели
            Game.Player.TurretSpawned(data);

            node.IsOccupied = true; // tryOccupy()
            m_Grid.UpdatePathFinding();
        }
    }
}
