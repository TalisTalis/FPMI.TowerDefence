using UnityEngine;

namespace Field
{
    public class Node
    {
        public Vector3 Position;

        // указание следующей ноды
        public Node NextNode;

        // дать возможность быть занятой
        public bool IsOccupied;

        // введение весов нодам
        public float PatWeight;

        // конструктор куда передается позиция
        public Node(Vector3 position)
        {
            Position = position;
        }

        // метод сброса веса нода
        public void ResetWeight()
        {
            // изначально у нода максимально возможное число (максимальный вес)
            PatWeight = float.MaxValue;
        }
    }
}
