using UnityEngine;

namespace Field
{
    public class GridHolder : MonoBehaviour
    {
        // задать ту ширину и высоту которую будем передавать в класс
        [SerializeField]
        private int m_GridWidth;
        [SerializeField]
        private int m_GridHeight;

        // размер нода
        [SerializeField]
        private float m_NodeSize;

        // создание сетки
        private Grid m_Grid;

        // откуда будем целиться мушкой
        private Camera m_Camera;

        // переменная для вычисления оффсета (нахождение левого нижнего угла плоскости)
        private Vector3 m_Offset;

        // лучше умножение вместо деления
        // создание сетки до метода старт
        public void Awake()
        {
            m_Grid = new Grid(m_GridWidth, m_GridHeight);
            m_Camera = Camera.main;
            
            float width = m_GridWidth * m_NodeSize;
            float height = m_GridHeight * m_NodeSize;

            // установка размера плоскости от ширины, высоты и размера нода
            transform.localScale = new Vector3(width * 0.1f, 
                                                1f, 
                                                height * 0.1f);

            // вычисление левого нижнего края (центр плоскости минус половину ширину и высоту)
            m_Offset = transform.position - (new Vector3(width, 0f, height) * 0.5f);
        }

        private void Update()
        {
            if (m_Grid == null || m_Camera == null)
            {
                return;
            }
            
            // получение текущего положения мышки
            Vector3 mousePosition = Input.mousePosition;

            // создать луч от точки до точки
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);

            // каст проверка колайдера на попадание
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // проверка попали ли в себя же
                if (hit.transform != transform)
                {
                    return;
                }

                // точка в которую попадает курсор мыши (вектор из угла куда попал указатель мыши)
                Vector3 hitPosition = hit.point;

                // разница между векторами
                Vector3 difference = hitPosition - m_Offset;

                // деление на размер нода даст координату куда попал указатель
                int x = (int)(difference.x / m_NodeSize);

                int y = (int)(difference.z / m_NodeSize);

                // попадание
                Debug.Log(x.ToString() + " " + y.ToString());
            }
        }

        // метод виден только в редакторе
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(m_Offset, 0.1f);
        }

        private void OnValidate()
        {
            if (m_Grid == null || m_Camera == null)
            {
                return;
            }

            // получение текущего положения мышки
            Vector3 mousePosition = Input.mousePosition;

            // создать луч от точки до точки
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);

            // каст проверка колайдера на попадание
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // проверка попали ли в себя же
                if (hit.transform != transform)
                {
                    return;
                }

                // точка в которую попадает курсор мыши (вектор из угла куда попал указатель мыши)
                Vector3 hitPosition = hit.point;

                // разница между векторами
                Vector3 difference = hitPosition - m_Offset;

                // деление на размер нода даст координату куда попал указатель
                int x = (int)(difference.x / m_NodeSize);

                int y = (int)(difference.z / m_NodeSize);

                // попадание
                Debug.Log(x.ToString() + " " + y.ToString());
            }
        }
    }
}
