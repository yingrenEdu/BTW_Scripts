using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class ICharacterAttribute {
        protected string mName;
        protected int mMaxHP;
        protected float mMoveSpeed;
        protected string mIconSprite;
        protected string mPrefabName;

        protected float mCurrentHP;
        protected int mLevel;
        /// <summary>
        /// 暴击率
        /// </summary>
        protected float mCritRate;
        /// <summary>
        /// 伤害抵消
        /// </summary>
        protected float mDmgDescValue;



        public ICharacterAttribute (IAttributeStrategy _mStrategy, string _name, int _hp, float _moveSpeed, string _iconSprite, string _prefabName) {
            mName = _name;
            mMoveSpeed = _moveSpeed;
            mIconSprite = _iconSprite;
            mPrefabName = _prefabName;
            mStrategy = _mStrategy;
            // 这里采用这种赋值方法是假设创建出角色之后等级不会变化的情况
            // 如果等级需要变化，则需要在属性中直接通过GET方法取值
            // HP同理
            mDmgDescValue = _mStrategy.GetDamageDecreaseValue(mLevel);
            mCurrentHP = mMaxHP + mStrategy.GetExtralHPValue(mLevel);
        }

        protected IAttributeStrategy mStrategy;

        /// <summary>
        /// 暴击值
        /// </summary>
        public float CritValue { get { return mStrategy.GetCritDamage(mCritRate); } }

        public float CurrentHp { get { return mCurrentHP; } }
        public void TakeDamage (float _damage) {
            _damage -= mDmgDescValue;
            if (_damage > 0)
                mCurrentHP -= _damage;
        }
    }
}
