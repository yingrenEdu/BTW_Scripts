using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public class WeaponSword : IWeapon {
        public override void Fire(Vector3 _targetPos) {
            Debug.Log("<color=green>" + "显示Sword攻击特效{0}" + "</color>");
            Debug.Log("<color=green>" + "播放Sword声音{0}" + "</color>");
        }
    }
}

