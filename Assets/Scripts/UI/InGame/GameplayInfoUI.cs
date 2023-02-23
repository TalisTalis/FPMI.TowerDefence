using RunTime;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.InGame
{
    public class GameplayInfoUI : MonoBehaviour
    {
        [SerializeField]
        private Text m_HealthText;
        [SerializeField]
        private Text m_MoneyText;
        [SerializeField]
        private Text m_WaveText;

        // подписаться на события
        private void OnEnable()
        {
            SetHealth(Game.Player.Health);
            SetMoney(Game.Player.TurretMarket.Money);

            Game.Player.HealthChanged += SetHealth;
            Game.Player.TurretMarket.MoneyChanged += SetMoney;
        }

        // отписаться от событий
        private void OnDisable()
        {
            Game.Player.HealthChanged -= SetHealth;
            Game.Player.TurretMarket.MoneyChanged -= SetMoney;
        }
        private void SetHealth(int health)
        {
            m_HealthText.text = $"Health: {health.ToString()}";
        }

        private void SetMoney(int money)
        {
            m_MoneyText.text = $"Money: {money.ToString()}";
        }
    }
}
