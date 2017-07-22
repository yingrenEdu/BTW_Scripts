using System;
using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;

namespace BTW.Game {
    public class ElfFactory : ICharacterFactory {
        public ICharacter CreateCharacter<T>(WeaponType _weaponType, Vector3 _spawnPosition, int _lv = 1) where T : ICharacter, new() {
            ICharacter character = new T();

            // 创建角色游戏物体

            // 添加武器

            string mName = "";
            int mMaxHP = 0;
            float mMoveSpeed = 0;
            string mIconSprite = "";
            string mPrefabName = "";

            Type t = typeof(T);
            if (t == typeof(ElfGhost)) {
                mName = "Ghost";
                mMaxHP = 100;
                mMoveSpeed = 3;
                mIconSprite = "";
                mPrefabName = "";
            }

            ICharacterAttribute attr = new IEnemyAttribute(new ElfAttributeStrategy(), mName, mMaxHP, mMoveSpeed, mIconSprite, mPrefabName);

            return null;
        }
    }
}

