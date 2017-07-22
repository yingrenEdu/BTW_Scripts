using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class IEnemyAttribute : ICharacterAttribute {
        public IEnemyAttribute(IAttributeStrategy _mStrategy, string _name, int _hp, float _moveSpeed, string _iconSprite, string _prefabName) : base(_mStrategy, _name, _hp, _moveSpeed, _iconSprite, _prefabName) {
        }
    }
}

