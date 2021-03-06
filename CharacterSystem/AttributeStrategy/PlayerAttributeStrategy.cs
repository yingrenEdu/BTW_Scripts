﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


namespace BTW.Game {
    public class PlayerAttributeStrategy : IAttributeStrategy {
        public float GetExtralHPValue(int _level) {
            return (_level - 1) * 10;
        }

        public float GetDamageDecreaseValue(int _level) {
            return (_level - 1) * 5;
        }

        public float GetCritDamage(float _critRate) {
            throw new System.NotImplementedException();
        }

        public float GetCritDamage(int _critRate) {
            return 0;
        }
    }
}

