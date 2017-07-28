/********************************************************************
  filename: ICharacterBuilder 
    author: Roy Zhu

   purpose: 建造者模式基类
*********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public abstract class ICharacterBuilder {
        protected ICharacter mCharacter;
        protected Type mType;
        protected WeaponType mWeaponType;
        protected Vector3 mSpawnPosition;
        protected int mLv;      
        protected string mPrefabName;

        public ICharacterBuilder(ICharacter _character, Type _type, WeaponType _weaponType, Vector3 _spawnPosition, int _lv) {
            mCharacter = _character;
            mType = _type;
            mWeaponType = _weaponType;
            mSpawnPosition = _spawnPosition;
            mLv = _lv;
        }

        public abstract void AddCharacterAttr ();
        public abstract void AddGameObject();
        public abstract void AddWeapon();
        public abstract ICharacter GetResult ();
    }
}


