/********************************************************************
  filename: CharacterBaseAttribute 
    author: Roy Zhu

   purpose: 角色基础属性 - 享元模式
*********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class CharacterBaseAttribute {
        #region 生成之后不会再次变动的属性，可以采用共享方式来节省内存
        protected string mName;
        protected int mMaxHP;
        protected float mMoveSpeed;
        protected string mIconSprite;
        protected string mPrefabName;
        /// <summary>
        /// 暴击率
        /// </summary>
        protected float mCritRate;

        public string Name { get { return mName; } }
        public int MaxHP { get { return mMaxHP; } }
        public float MoveSpeed { get { return mMoveSpeed; } }
        public string IconSprite { get { return mIconSprite; } }
        public string PrefabName { get { return mPrefabName; } }
        public float CritRate { get { return mCritRate; } }
        #endregion

        public CharacterBaseAttribute (string _name, int _maxHP, float _moveSpeed, string _iconSprite, string _prefabName, float _critRate) {
            mName = _name;
            mMaxHP = _maxHP;
            mMoveSpeed = _moveSpeed;
            mIconSprite = _iconSprite;
            mPrefabName = _prefabName;
            mCritRate = _critRate;
        }
    }
}

