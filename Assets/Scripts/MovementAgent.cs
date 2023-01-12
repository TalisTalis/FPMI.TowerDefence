using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAgent : MonoBehaviour
{
    private float m_Speed;
    private Vector3 m_Target;

    private const float TOLERANCE = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // установить скорость
        m_Speed = 5f;
        m_Target = new Vector3(10f, 0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        // расстояние до цели
        float distance = (m_Target - transform.position).magnitude;

        // проверка на сколько близко подошли к цели
        if (distance < TOLERANCE)
        {
            return;
        }
        // найдем направление в доль которого нужно двигаться
        // позиция цели и минус позиция предмета
        Vector3 dir = (m_Target - transform.position).normalized;

        // определить скорость с которой будет двигаться объект к цели
        Vector3 delta = dir * (m_Speed * Time.deltaTime);

        transform.Translate(delta);
    }
}
