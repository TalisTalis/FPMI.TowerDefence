using RunTime;
using Turret;

namespace Weapon
{
    public class TurretShootController : IController
    {
        public void OnStart()
        {            
        }

        public void OnStop()
        {            
        }

        public void Tick()
        {
            foreach (TurretData turretData in Game.Player.TurretDatas)
            {
                // проходим по туррелям и вызываем метод тикшут
                turretData.Weapon.TickShoot();
            }
        }
    }
}
