using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class ElfBuilder : ICharacterBuilder {
        public ElfBuilder (ICharacter _character, Type _type, WeaponType _weaponType, Vector3 _spawnPosition, int _lv) : base(_character, _type, _weaponType, _spawnPosition, _lv) {
        }

        public override void AddCharacterAttr() {
            string mName = "";
            int mMaxHP = 0;
            float mMoveSpeed = 0;
            string mIconSprite = "";

            if (mType == typeof(ElfGhost)) {
                mName = "Ghost";
                mMaxHP = 100;
                mMoveSpeed = 3;
                mIconSprite = "";
                mPrefabName = "";
            }

            ICharacterAttribute attr = new IElfAttribute(new ElfAttributeStrategy(), mLv, mName, mMaxHP, mMoveSpeed, mIconSprite, mPrefabName);
            mCharacter.CharacterAttr = attr;
        }

        public override void AddGameObject() {
            var characterGO = FactoryManager.AssetFactory.LoadElf(mPrefabName);
            characterGO.transform.position = mSpawnPosition;
            mCharacter.GO = characterGO;
        }

        public override void AddWeapon() {
            var weapon = FactoryManager.WeaponFactory.CreateWeapon(mWeaponType);
            mCharacter.Weapon = weapon;
        }

        public override ICharacter GetResult () {
            return mCharacter;
        }

    }
}

