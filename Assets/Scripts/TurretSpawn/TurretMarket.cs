using Turret;

namespace TurretSpawn
{
    public class TurretMarket
    {
        private TurretMarketAsset m_Asset;

        // конструктор
        public TurretMarket(TurretMarketAsset asset)
        {
            m_Asset = asset;
        }

        // пока выбор первой башни из списка
        public TurretAsset ChosenTurret => m_Asset.TurretAssets[0];
    }
}
