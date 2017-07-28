/********************************************************************
  filename: ElfFactory
    author: Roy Zhu

   purpose: 通过建造者模式创建精灵
*********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;

namespace BTW.Game {
    public class ElfFactory : ICharacterFactory {
        public ICharacter CreateCharacter<T>(WeaponType _weaponType, Vector3 _spawnPosition, int _lv = 1) where T : ICharacter, new() {
            ICharacter character = new T();
            ICharacterBuilder builder = new ElfBuilder(character, typeof(T), _weaponType, _spawnPosition, _lv);
            return CharacterBuilderDirector.Construct(builder);
        }
    }
}

