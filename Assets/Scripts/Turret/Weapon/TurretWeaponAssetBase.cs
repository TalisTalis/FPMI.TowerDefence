using Turret;
using UnityEngine;

namespace Weapon
{
    // его создать нельзя его толькоможно наследовать и методы его нужно реализовать в наследниках
    public abstract class TurretWeaponAssetBase : ScriptableObject
    {
        // абстрактный метод создания оружия
        public abstract ITurretWeapon GetWeapon(TurretView view);
    }
}
