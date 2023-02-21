using UnityEngine;
using Field;

namespace Assets
{
    public class GridMovementAgent : IMovementAgent
    {
        private float m_Speed;

        // убрали наслодование от MonoBehavior поэтому трансформ передаем отдельно
        private Transform m_Transform;

        // конструктор который задает скорость и трансформ
        public GridMovementAgent(float speed, Transform transform, Field.Grid grid)
        {
            m_Speed = speed;
            m_Transform = transform;

            // обозначим стартовую ноду
            SetTargetNode(grid.GetStartNode());
        }

        private const float TOLERANCE = 0.1f;

        private Node m_TargetNode;

        public void TickMovement()
        {
            if (m_TargetNode == null)
            {
                return;
            }

            Vector3 target = m_TargetNode.Position;

            float distance = (target - m_Transform.position).magnitude;
            if (distance < TOLERANCE)
            {
                m_TargetNode = m_TargetNode.NextNode;
                return;
            }

            Vector3 dir = (target - m_Transform.position).normalized;
            Vector3 delta = dir * (m_Speed * Time.deltaTime);
            m_Transform.Translate(delta);
        }

        // метод задает конечную ноду в которую мы идем
        private void SetTargetNode(Node node)
        {
            m_TargetNode = node;
        }

        public Node GetCurrentNode()
        {
            // когда подошли к ноде то мы уже там. не баг а фича
            return m_TargetNode;
        }
    }
}