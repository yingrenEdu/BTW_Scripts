﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class WeaponSword : IWeapon {
        public WeaponSword (float _atkPower, float _atkRange, GameObject _gameObject) : base(_atkPower, _atkRange, _gameObject) {
        }

        protected override void SetEffectDisplayTime() {
            throw new System.NotImplementedException();
        }

        protected override void PlayBulletEffect(Vector3 _targetPos) {
            throw new System.NotImplementedException();
        }

        protected override void PlaySound() {
            throw new System.NotImplementedException();
        }


    }
}

