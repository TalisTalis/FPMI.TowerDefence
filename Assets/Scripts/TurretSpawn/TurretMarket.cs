﻿using Assets;
using RunTime;
using System;
using Turret;
using UnityEngine;

namespace TurretSpawn
{
    public class TurretMarket
    {
        private TurretMarketAsset m_Asset;
        private int m_Money;

        public int Money => m_Money;
        public event Action<int> MoneyChanged;

        // конструктор
        public TurretMarket(TurretMarketAsset asset)
        {
            m_Asset = asset;
            m_Money = Game.CurrentLevel.StartMoney;
        }

        // пока выбор первой башни из списка
        public TurretAsset ChosenTurret 
                    => m_Money < m_Asset.TurretAssets[0].Price ? null : m_Asset.TurretAssets[0];

        public void BuyTurret(TurretAsset turretAsset)
        {
            if (turretAsset.Price > m_Money)
            {
                Debug.Log("Not enough money!");
            }
            m_Money -= turretAsset.Price;
            MoneyChanged?.Invoke(m_Money);
        }

        public void GetReward(EnemyData enemyData)
        {
            m_Money += enemyData.Asset.Reward;
            MoneyChanged?.Invoke(m_Money);
        }
    }
}
