using Enemy;
using UnityEngine;

namespace RunTime
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private AssetRoot m_AssetRoot;

        private void Awake()
        {
            Game.SetAssetRoot(m_AssetRoot);
        }

        // проверка. если нажали на пробел то загружается первый уровень
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Game.StartLevel(m_AssetRoot.Levels[0]);
            }
        }
    }
}
