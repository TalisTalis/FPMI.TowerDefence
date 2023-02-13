using System.Collections.Generic;
using UnityEngine;

namespace Field
{
    public class Grid
    {
        // хранение нода
        private Node[,] m_Nodes;

        // размер сетки
        private int m_Width;
        private int m_Height;

        // координаты начало пути врагов и цели врагов
        private Vector2Int m_StartCoordinate;
        private Vector2Int m_TargetCoordinate;

        // хранение выбранной ноды
        private Node m_SelectedNode = null;

        private FlowFieldPathfinding m_Pathfinding;

        // публичные свойства
        public int Width => m_Width;
        public int Height => m_Height;

        // конструктор сетки
        public Grid(int width, int height, Vector3 offset, float nodeSize, Vector2Int startCoordinate, Vector2Int target)
        {
            m_Width = width;
            m_Height = height;

            m_StartCoordinate = startCoordinate;
            m_TargetCoordinate = target;

            // создаем массив
            m_Nodes = new Node[m_Width, m_Height];

            // проходим по массиву для создания новых нодов
            for (int i = 0; i < m_Nodes.GetLength(0); i++)
            {
                for (int j = 0; j < m_Nodes.GetLength(1); j++)
                {
                    m_Nodes[i, j] = new Node(offset + new Vector3(i + .5f, 0f, j + .5f) * nodeSize);
                }
            }

            m_Pathfinding = new FlowFieldPathfinding(this, target);

            // обновляем поле
            m_Pathfinding.UpdateField();
        }

        // метод который возвращает стартовый нод
        public Node GetStartNode()
        {
            return GetNode(m_StartCoordinate);
        }

        // метод который возвращает нод цели
        public Node GetTargetNode()
        {
            return GetNode(m_TargetCoordinate);
        }

        public void SelectedCoordinate(Vector2Int coordinate)
        {
            m_SelectedNode = GetNode(coordinate);
        }

        public void UnselectNode()
        {
            m_SelectedNode = null;
        }

        public Node GetSelectedNode ()
        {
            return m_SelectedNode;
        }

        public bool HasSelectedNode()
        {
            return m_SelectedNode != null;
        }
        public Node GetNode (Vector2Int coordinate)
        {
            return GetNode(coordinate.x, coordinate.y);
        }

        // достает нод по каким-нибудь координатам
        public Node GetNode(int i, int j)
        {
            // проверка не лежат ли i и j вне допустимого диапазона
            if (i < 0 || i >= m_Width)
            {
                return null;
            }

            if (j < 0 || j >= m_Height)
            {
                return null;
            }

            return m_Nodes[i, j];
        }

        // метод который проходит по всем нодам
        public IEnumerable<Node> EnumerateAllNodes()
        {
            // проход по строкам сетки
            for (int i = 0; i < m_Width; i++)
            {
                // проход по ячейкам сетки
                for (int j = 0; j < m_Height; j++)
                {
                    // возврат 
                    yield return GetNode(i, j);
                }
            }
        }

        public void UpdatePathFinding()
        {
            m_Pathfinding.UpdateField();
        }
    }
}
