using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class ICharacterAttribute {
        protected CharacterBaseAttribute mBaseAttr;

        protected float mCurrentHP;
        protected int mLevel;
        /// <summary>
        /// 伤害抵消
        /// </summary>
        protected float mDmgDescValue;

        public ICharacterAttribute (IAttributeStrategy _mStrategy, int _lv, CharacterBaseAttribute _baseAttr) {
            mStrategy = _mStrategy;
            mLevel = _lv;
            mBaseAttr = _baseAttr;
            // 这里采用这种赋值方法是假设创建出角色之后等级不会变化的情况
            // 如果等级需要变化，则需要在属性中直接通过GET方法取值
            // HP同理
            mDmgDescValue = _mStrategy.GetDamageDecreaseValue(mLevel);
            mCurrentHP = _baseAttr.MaxHP + mStrategy.GetExtralHPValue(mLevel);
        }

        protected IAttributeStrategy mStrategy;

        /// <summary>
        /// 暴击值
        /// </summary>
        public float CritValue { get { return mStrategy.GetCritDamage(mBaseAttr.CritRate); } }

        public float CurrentHp { get { return mCurrentHP; } }
        public void TakeDamage (float _damage) {
            _damage -= mDmgDescValue;
            if (_damage > 0)
                mCurrentHP -= _damage;
        }
    }
}
