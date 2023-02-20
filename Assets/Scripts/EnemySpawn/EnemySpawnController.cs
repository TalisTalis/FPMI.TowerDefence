using Assets;
using Field;
using RunTime;
using System.Collections;
using UnityEngine;

namespace EnemySpawn
{
    public class EnemySpawnController : IController
    {
        // ссылка на спавнер
        private SpawnWavesAsset m_SpawnWaves;
        // ссылка на сетку чтобы знать куда спавнить юнита
        private Field.Grid m_Grid;

        private IEnumerator m_SpawnRoutine;

        private float m_WaitTime;

        // конструктор в который будут передаваться ссылки на спавнер и сетку
        public EnemySpawnController(SpawnWavesAsset spawnWaves, Field.Grid grid)
        {
            m_SpawnWaves = spawnWaves;
            m_Grid = grid;
        }

        public void OnStart()
        {
            m_WaitTime = Time.time;
            m_SpawnRoutine = SpawnRoutine(); // просто создание объекта
        }

        public void OnStop()
        {

        }

        public void Tick()
        {
            // реализовать ожидание
            // в момент когда получили waitForSeconds можем сохранить время до которого
            // нам нужно ждать чтобы ничего не происходило
            // в начале тика проверять это время
            if (m_WaitTime > Time.time)
            {
                return;
            }
            if (m_SpawnRoutine.MoveNext())
            {
                if (m_SpawnRoutine.Current is CustomWaitForSeconds waitForSeconds)
                {
                    m_WaitTime = Time.time + waitForSeconds.Seconds;
                }
            }
        }

        private IEnumerator SpawnRoutine()
        {
            foreach (SpawnWave wave in m_SpawnWaves.SpawnWaves)
            {
                yield return new CustomWaitForSeconds(wave.TimeBeforeStartWave);

                for (int i = 0; i < wave.Count; i++)
                {
                    SpawnEnemy(wave.EnemyAsset);

                    if (i < wave.Count - 1)
                    {
                        yield return new CustomWaitForSeconds(wave.TimeBetweenSpawns);
                    }
                }

                // TODO: show wave number
            }

            Game.Player.LastWaveSpawned();
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

        private class CustomWaitForSeconds
        {
            public readonly float Seconds;

            public CustomWaitForSeconds(float seconds)
            {
                Seconds = seconds;
            }
        }
    }
}
