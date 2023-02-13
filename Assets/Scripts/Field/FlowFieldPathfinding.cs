using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

namespace Field
{
    internal class FlowFieldPathfinding
    {
        // метод поиска путей
        // ссылка на Grid
        private Grid m_Grid;

        // понадобится таргет
        private Vector2Int m_Target;

        // создание конструктора класса
        public FlowFieldPathfinding(Grid grid, Vector2Int target)
        {
            m_Grid = grid;
            m_Target = target;
        }

        // метод обновления всего поля
        public void UpdateField()
        {
            // всем нодам сбросили веса (устанавливаем максимальные веса)
            foreach (Node node in m_Grid.EnumerateAllNodes())
            {
                node.ResetWeight();
            }
            // создание очереди
            Queue<Vector2Int> queue = new Queue<Vector2Int> ();

            // проход начинается с таргета поэтому в очередь в начале нужно засунуть таргет
            queue.Enqueue(m_Target);

            // установка таргету вес ноль так как путь от таргета к таргету ноль
            m_Grid.GetNode(m_Target).PatWeight = 0f;

            // цикл пока очередь не пустая
            while (queue.Count > 0)
            {
                // берем из очереди первую верхнюю координату
                Vector2Int current = queue.Dequeue();

                Node currentNode = m_Grid.GetNode(current);

                // берем вес текущей ноды из очереди
                float weigthToTarget = currentNode.PatWeight + 1f;

                // пройтись по всем соседям
                foreach (Vector2Int neighbour in GetNeighbours(current))
                {
                    Node neighbourNode = m_Grid.GetNode(neighbour);

                    if (weigthToTarget < neighbourNode.PatWeight)
                    {
                        // устанавливаем текущую ноду соседней
                        neighbourNode.NextNode = currentNode;

                        // устанавливаем соседней ноде вес цели
                        neighbourNode.PatWeight = weigthToTarget;

                        // добавление соседа в очередь
                        queue.Enqueue(neighbour);                        
                    }
                }
            }
        }

        // метод получения всех соседей (интерфейс который реализует множество структур)
        private IEnumerable<Vector2Int> GetNeighbours(Vector2Int coordinate)
        {
            // сам метод создает IEnumerable который по очереди возвращает координату в порядке исполнения кода

            // координата справа
            Vector2Int rightCoordinate = coordinate + Vector2Int.right;

            // координата слева
            Vector2Int leftCoordinate = coordinate + Vector2Int.left;

            // координата сверху
            Vector2Int upCoordinate = coordinate + Vector2Int.up;

            // координата снизу
            Vector2Int downCoordinate = coordinate + Vector2Int.down;

            // проверка попадают ли эти координаты в поле и не заняты ли они туреллями
            bool hasRightNode = rightCoordinate.x < m_Grid.Width && !m_Grid.GetNode(rightCoordinate).IsOccupied;
            bool hasLeftNode = leftCoordinate.x >= 0 && !m_Grid.GetNode(leftCoordinate).IsOccupied;
            bool hasUpNode = upCoordinate.y < m_Grid.Height && !m_Grid.GetNode(upCoordinate).IsOccupied;
            bool hasDownNode = downCoordinate.y >= 0 && !m_Grid.GetNode(downCoordinate).IsOccupied;

            if (hasRightNode)
            {
                yield return rightCoordinate;
            }

            if (hasLeftNode)
            {
                yield return leftCoordinate;
            }

            if (hasUpNode)
            {
                yield return upCoordinate;
            }

            if (hasDownNode)
            {
                yield return downCoordinate;
            }
        }
    }
}
