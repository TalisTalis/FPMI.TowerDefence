using RunTime;
using Turret;

namespace Weapon
{
    public class TurretShootController : IController
    {
        void OnStart()
        {            
        }

        void OnStop()
        {            
        }

        void Tick()
        {
            foreach (TurretData turretData in Game.Player.TurretDatas)
            {
                // проходим по туррелям и вызываем метод тикшут
                turretData.Weapon.TickShoot();
            }
        }
    }
}
