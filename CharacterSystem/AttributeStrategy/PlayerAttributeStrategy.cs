using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BTW.Framework {
    public class PlayerAttributeStrategy : IAttributeStrategy {
        public float GetExtralHPValue(int _level) {
            return (_level - 1) * 10;
        }

        public float GetDamageDecreaseValue(int _level) {
            return (_level - 1) * 5;
        }

        public float GetCritDamage(int _critRate) {
            return 0;
        }
    }
}

