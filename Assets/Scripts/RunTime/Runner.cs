using Enemy;
using EnemySpawn;
using Field;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RunTime
{
    // хранит все контроллеры и тикает по ним
    public class Runner : MonoBehaviour
    {
        private List<IController> m_Controllers;

        // подтверждение что контроллеры созданы
        private bool m_IsRunning = false;

        private void Update()
        {
            if (!m_IsRunning)
                return;

            TickControllers();
        }

        // метод который говорит что мы начали работать
        public void StartRunning ()
        {
            CreateAllControllers();
            OnStartControllers();
            m_IsRunning = true;
        }

        public void StopRunning()
        {
            OnStopControllers();
            m_IsRunning = false;
        }

        private void CreateAllControllers()
        {
            m_Controllers = new List<IController>()
            {
                new GridPointerController(Game.Player.GridHolder),
                new EnemySpawnController(Game.CurrentLevel.SpawnWavesAsset, Game.Player.Grid),
                new MovementController()
            };
        }

        private void OnStartControllers()
        {
            foreach (var controller in m_Controllers)
            {
                // если один из контроллеров сломается, то остальные продолжат работу
                try
                {
                    controller.OnStart();
                }
                catch (Exception e)
                {

                    Debug.LogError(e);
                }                
            }
        }

        private void TickControllers()
        {
            foreach (var controller in m_Controllers)
            {
                // если один из контроллеров сломается, то остальные продолжат работу
                try
                {
                    controller.Tick();
                }
                catch (Exception e)
                {

                    Debug.LogError(e);
                }
            }
        }

        private void OnStopControllers()
        {
            foreach (var controller in m_Controllers)
            {
                // если один из контроллеров сломается, то остальные продолжат работу
                try
                {
                    controller.OnStop();
                }
                catch (Exception e)
                {

                    Debug.LogError(e);
                }
            }
        }
    }
}
