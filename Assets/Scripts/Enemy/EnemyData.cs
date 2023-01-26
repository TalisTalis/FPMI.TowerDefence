using Enemy;

namespace Enemy
{
    public class EnemyData
    {
        // ссылка на вью
        private EnemyView m_View;

        public EnemyView View => m_View;

        // конструктор
        public EnemyData(EnemyAsset asset)
        {

        }

        public void AttachView(EnemyView view)
        {
            m_View = view;
            m_View.AttachData(this);
        }
    }
}
