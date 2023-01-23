using Assets;
using Enemy;
using Field;
using RunTime;
using UnityEngine;

namespace EnemySpawn
{
    public class EnemySpawnController : IController
    {
        // ссылка на спавнер
        private SpawnWavesAsset m_SpawnWaves;
        // ссылка на сетку чтобы знать куда спавнить юнита
        private Field.Grid m_Grid;

        private float m_SpawnStartTime;
        private float m_PassedTimeAPreviousFrame = -1f;

        // конструктор в который будут передаваться ссылки на спавнер и сетку
        public EnemySpawnController(SpawnWavesAsset spawnWaves, Field.Grid grid)
        {
            m_SpawnWaves = spawnWaves;
            m_Grid = grid;
        }

        public void OnStart()
        {
            m_SpawnStartTime = Time.time;
        }

        public void OnStop() 
        {

        }

        public void Tick()
        {
            // сколько прошло времени с начала работы контроллера
            float passedTime = Time.time - m_SpawnStartTime;
            // время когда нужно спавнить
            float timeToSpawn = 0f;

            // проходим по всем волнам
            foreach (SpawnWave wave in m_SpawnWaves.SpawnWaves)
            {
                timeToSpawn += wave.TimeBeforeStartWave;

                // по количеству юнитов
                for (int i = 0; i < wave.Count; i++)
                {
                    // логика нужно ли спавнить или нет
                    if (passedTime >= timeToSpawn && m_PassedTimeAPreviousFrame < timeToSpawn)
                    {
                        SpawnEnemy(wave.EnemyAsset);
                    }

                    // после спавна последнего юнита время не прибавлять
                    if (i < wave.Count - 1)
                    {
                        timeToSpawn += wave.TimeBetweenSpawns;
                    }
                }
            }

            m_PassedTimeAPreviousFrame = passedTime;
        }

        // метод спавна одного врага
        private void SpawnEnemy(EnemyAsset asset)
        {
            EnemyView view = Object.Instantiate(asset.ViewPrefab);
            // поставить вью в стартовую ноду
            view.transform.position = m_Grid.GetStartNode().Position;
            EnemyData data = new EnemyData(asset);

            data.AttachView(view);
            view.CreateMovementAgent(m_Grid);

            Game.Player.EnemySpawned(data);
        }
    }
}
