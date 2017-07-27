using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public interface IWeaponFactory {
        IWeapon CreateWeapon(WeaponType _type);
    }
}

