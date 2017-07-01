using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {

    public class EnemyAttributeStrategy : IAttributeStrategy {
        public float GetExtralHPValue(int _level) {
            return 0;
        }

        public float GetDamageDecreaseValue(int _level) {
            return 0;
        }

        public float GetCritDamage(int _critRate) {
            if (Random.Range(0, 1f) < _critRate) {
                return 10 * Random.Range(0, 0.5f);
            }
            return 0;
        }
    }
}


