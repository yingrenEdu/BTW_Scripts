using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;

namespace BTW.Game {
    public class EnemyFactory : ICharacterFactory {
        public ICharacter CreateCharacter<T> (WeaponType _weaponType, Vector3 _spawnPosition, int _lv = 1) where T : ICharacter, new() {
            ICharacter iCharacter = new T();
            throw new System.NotImplementedException();
        }
    }
}

