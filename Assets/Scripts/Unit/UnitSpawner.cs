using Field;
using System.Collections;
using UnityEngine;

namespace Unit
{
    public class UnitSpawner : MonoBehaviour 
    {
        [SerializeField]
        private GridMovementAgent m_MovementAgent;
        [SerializeField]
        private GridHolder m_GrigHolder;

        private void Awake()
        {
            StartCoroutine(SpawnUnitCorountin());
        }

        // ��� � ������� �������� ������
        private IEnumerator SpawnUnitCorountin()
        {
            while (true)
            {
                // ����� ������ ������� �������� �����
                yield return new WaitForSeconds(1f);
                SpawnUnit();
            }
        }

        // ����� ������ ������
        private void SpawnUnit()
        {
            Node startNode = m_GrigHolder.Grid.GetNode(m_GrigHolder.StartCoordinate);
            Vector3 position = startNode.Position;
            GridMovementAgent movementAgent = Instantiate(m_MovementAgent, position, Quaternion.identity);
            movementAgent.SetStartNode(startNode);
        }
    }    
}
