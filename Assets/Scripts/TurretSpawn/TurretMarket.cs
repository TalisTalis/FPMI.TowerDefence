using Assets;
using RunTime;
using System;
using Turret;
using UnityEngine;

namespace TurretSpawn
{
    public class TurretMarket
    {
        private TurretAsset m_ChoosenTurret;
        private int m_Money;

        public int Money => m_Money;
        public event Action<int> MoneyChanged;

        // конструктор
        public TurretMarket()
        {
            m_Money = Game.CurrentLevel.StartMoney;
        }

        // пока выбор первой башни из списка
        public TurretAsset ChosenTurret
        {
            get
            {
                if (m_ChoosenTurret == null)
                {
                    return null;
                }
                return m_ChoosenTurret.Price > m_Money ? null : m_ChoosenTurret;
            }
        }
        
        public void ChooseTurret(TurretAsset asset)
        {
            if (asset.Price > m_Money)
            {
                return;
            }
            m_ChoosenTurret = asset;
        }

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
