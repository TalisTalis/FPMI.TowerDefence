using UnityEngine;
using Field;

namespace Unit
{  
  public class GridMovementAgent : MonoBehaviour 
  {    
    // Update is called once per frame
    [SerializeField]
    private float m_Speed;

    private const float TOLERANCE = 0.1f;

    private Node m_TargetNode;

    // Update is called once per frame
    private void Update()
    {
      if (m_TargetNode == null)
      {
        return;
      }

      Vector3 target = m_TargetNode.Position;
      
      float distance = (target - transform.position).magnitude;
      if (distance < TOLERANCE)
      {
        m_TargetNode = m_TargetNode.NextNode;
          return;
      }

      Vector3 dir = (target - transform.position).normalized;
      Vector3 delta = dir * (m_Speed * Time.deltaTime);
      transform.Translate(delta);
    }

    // метод задает стартовую ноду из которой мы вышли
    public void SteStartNode(Node node)
    {
      m_TargetNode = node;
    }
  }
}