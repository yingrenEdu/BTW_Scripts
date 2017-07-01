using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public interface IAttributeStrategy {
        /// <summary>
        /// 获得增加的HP最大值
        /// </summary>
        /// <returns></returns>
        float GetExtralHPValue(int _level);
        /// <summary>
        ///  获得抵御的伤害值
        /// </summary>
        /// <returns></returns>
        float GetDamageDecreaseValue(int _level);
        /// <summary>
        /// 增加暴击伤害
        /// </summary>
        /// <param name="_critRate"></param>
        /// <returns></returns>
        float GetCritDamage(int _critRate);
    }
}

