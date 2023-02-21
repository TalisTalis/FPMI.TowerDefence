using Weapon;
using Assets;
using EnemySpawn;
using Field;
using System;
using System.Collections.Generic;
using TurretSpawn;
using UnityEngine;
using Assets.Scripts.Enemy;
using Assets.Scripts.Main;

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
                new GridRaycastController(Game.Player.GridHolder),
                new EnemySpawnController(Game.CurrentLevel.SpawnWavesAsset, Game.Player.Grid),
                new TurretSpawnController(Game.Player.Grid, Game.Player.TurretMarket),
                new MovementController(),
                new EnemyReachController(Game.Player.Grid), // если враг дошел до цели и умер то он нанесет дамаг
                new TurretShootController(),
                new EnemyDeathController(),
                new LoseController(),
                new WinController()
            };
        }

        private void OnStartControllers()
        {
            foreach (IController controller in m_Controllers)
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
            foreach (IController controller in m_Controllers)
            {
                // если произойдет остановка, то дальше по спискам контроллеров не пойдет 
                if (!m_IsRunning)
                {
                    return;
                }

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
            foreach (IController controller in m_Controllers)
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
