using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class WeaponBow : IWeapon {
        public WeaponBow (float _atkPower, float _atkRange, GameObject _gameObject) : base(_atkPower, _atkRange, _gameObject) {
        }

        protected override void SetEffectDisplayTime() {
            mEffectDisplayTime = 0.2f;
        }

        protected override void PlayBulletEffect(Vector3 _targetPos) {
            DoPlayBulletEffect(_targetPos, 0.5f);
        }

        protected override void PlaySound() {
            DoPlaySound("GunShot");
        }


    }
}