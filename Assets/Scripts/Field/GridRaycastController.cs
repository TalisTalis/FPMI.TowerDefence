using RunTime;

namespace Field
{
    public class GridRaycastController : IController
    {
        private GridHolder m_GridHolder;

        // конструктор
        public GridRaycastController(GridHolder gridHolder)
        {
            m_GridHolder = gridHolder;
        }

        public void OnStart()
        {

        }

        public void OnStop()
        {

        }

        public void Tick()
        {
            m_GridHolder.RaycastInGrid();
        }
    }
}
