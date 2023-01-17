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

        // публичные свойства
        public int Width => m_Width;
        public int Height => m_Height;

        // конструктор сетки
        public Grid(int width, int height)
        {
            m_Width = width;
            m_Height = height;

            // создаем массив
            m_Nodes = new Node[m_Width, m_Height];

            // проходим по массивуу для создания новых нодов
            for (int i = 0; i < m_Nodes.GetLength(0); i++)
            {
                for (int j = 0; j < m_Nodes.GetLength(1); j++)
                {
                    m_Nodes[i, j] = new Node();
                }
            }
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
    }
}
