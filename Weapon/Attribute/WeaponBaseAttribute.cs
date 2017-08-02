/********************************************************************
  filename: WeaponBaseAttribute
    author: Roy Zhu

   purpose: 武器基础属性
*********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class WeaponBaseAttribute {
        protected string mName;
        protected float mAtkPower;
        protected float mAtkRange;
        protected string mPrefabName;

        public WeaponBaseAttribute (string _name, float _atkPower, float _atkRange, string _prefabName) {
            mName = _name;
            mAtkPower = _atkPower;
            mAtkRange = _atkRange;
            mPrefabName = _prefabName;
        }

        public string Name { get { return mName; } }
        public float AtkPower { get { return mAtkPower; } }
        public float AtkRange { get { return mAtkRange; } }
        public string PrefabName { get { return mPrefabName; } }
    }
}


