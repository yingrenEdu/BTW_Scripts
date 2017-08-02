using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class AttributeFactory : IAttributeFactory {
        private Dictionary<Type, CharacterBaseAttribute> mCharacterBaseAttributeDict;
        private Dictionary<WeaponType, WeaponBaseAttribute> mWeaponBaseAttributeDict;

        public AttributeFactory () {
            InitCharacterAttributeFactory();
        }

        private void InitCharacterAttributeFactory () {
            mCharacterBaseAttributeDict = new Dictionary<Type, CharacterBaseAttribute> {
                {typeof(ElfGhost), new CharacterBaseAttribute("Ghost", 100, 3, "", "", 0)},
                {typeof(EnemySwordman), new CharacterBaseAttribute("Swordman", 100, 3, "", "", 0)}
            };
        }

        private void InitWeaponAttributeFactory() {
            mWeaponBaseAttributeDict = new Dictionary<WeaponType, WeaponBaseAttribute> {
                {WeaponType.Bow, new WeaponBaseAttribute("Bow", 5, 20, "WeaopnBow") },
                {WeaponType.Sword, new WeaponBaseAttribute("Sword", 5, 20, "WeaopnSword") },
            };
        }

        public CharacterBaseAttribute GetCharacterBaseAttribute (Type _t) {
            if (mCharacterBaseAttributeDict.ContainsKey(_t) == false) {
                Debug.Log(string.Format("<color=red>" + "角色属性字典中没有包含键值：{0}的数值" + "</color>", _t));
                return null;
            }
            return mCharacterBaseAttributeDict[_t];
        }

        public WeaponBaseAttribute GetWeaponBaseAttribute(WeaponType _type) {
            if (mWeaponBaseAttributeDict.ContainsKey(_type) == false) {
                Debug.Log(string.Format("<color=red>" + "武器属性字典中没有包含键值：{0}的数值" + "</color>", _type));
                return null;
            }
            return mWeaponBaseAttributeDict[_type];
        }
    }
}


