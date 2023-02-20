using Assets;
using Assets.Scripts.Main;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunTime
{
    public static class Game
    {
        // поля
        // ссылка на игрока
        private static Player s_Player;
        private static AssetRoot s_AssetRoot;
        private static LevelAsset s_CurrentLevel;

        private static Runner m_Runner;

        // свойства
        public static Player Player => s_Player;
        public static AssetRoot AssetRoot => s_AssetRoot;
        public static LevelAsset CurrentLevel => s_CurrentLevel;

        // методы
        public static void SetAssetRoot(AssetRoot assetRoot)
        {
            s_AssetRoot = assetRoot;
        }

        public static void StartLevel(LevelAsset levelAsset)
        {
            s_CurrentLevel = levelAsset;

            // Загрузка уровня
            AsyncOperation operation = SceneManager.LoadSceneAsync(levelAsset.SceneAsset.name);
            operation.completed += StartPlayer;
        }

        // Создание класса Игрока
        private static void StartPlayer(AsyncOperation operation)
        {
            if (!operation.isDone)
            {
                throw new System.Exception("Can't load scene.");
            }
            s_Player = new Player();

            // нахождение раннера на сцене
            m_Runner = Object.FindObjectOfType<Runner>();
            m_Runner.StartRunning();
        }

        public static void StopPlayer()
        {
            m_Runner.StopRunning();
        }
    }
}
