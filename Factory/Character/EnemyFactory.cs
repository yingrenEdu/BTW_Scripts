/********************************************************************
  filename: EnemyFactory 
    author: Roy Zhu

   purpose: 通过建造者模式创建敌人
*********************************************************************/

using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;

namespace BTW.Game {
    public class EnemyFactory : ICharacterFactory {
        public ICharacter CreateCharacter<T> (WeaponType _weaponType, Vector3 _spawnPosition, int _lv = 1) where T : ICharacter, new() {
            ICharacter character = new T();
            ICharacterBuilder builder = new EnemyBuilder(character, typeof(T), _weaponType, _spawnPosition, _lv);
            return CharacterBuilderDirector.Construct(builder);

        }
    }
}

