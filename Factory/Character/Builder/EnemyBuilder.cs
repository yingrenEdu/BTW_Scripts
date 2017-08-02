using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class EnemyBuilder : ICharacterBuilder {
        public EnemyBuilder (ICharacter _character, Type _type, WeaponType _weaponType, Vector3 _spawnPosition, int _lv) : base(_character, _type, _weaponType, _spawnPosition, _lv) {
        }

        public override void AddCharacterAttr () {
            var baseAttr = FactoryManager.AttrFactory.GetCharacterBaseAttribute(typeof(ElfBuilder));
            mPrefabName = baseAttr.PrefabName;
            ICharacterAttribute attr = new IEnemyAttribute(new EnemyAttributeStrategy(), mLv, baseAttr);
            mCharacter.CharacterAttr = attr;
        }

        public override void AddGameObject () {
            var characterGO = FactoryManager.AssetFactory.LoadElf(mPrefabName);
            characterGO.transform.position = mSpawnPosition;
            mCharacter.GO = characterGO;
        }

        public override void AddWeapon () {
            var weapon = FactoryManager.WeaponFactory.CreateWeapon(mWeaponType);
            mCharacter.Weapon = weapon;
        }

        public override ICharacter GetResult () {
            return mCharacter;
        }
    }
}

