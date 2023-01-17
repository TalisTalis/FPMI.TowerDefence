namespace Field
{
    public class Node
    {
        // указание следующей ноды
        public Node NextNode;

        // дать возможность быть занятой
        public bool IsOccupied;

        // введение весов нодам
        public float PatWeight;

        // метод сброса веса нода
        public void ResetWeight()
        {
            // изначально у нода максимально возможное число (максимальный вес)
            PatWeight = float.MaxValue;
        }
    }
}
