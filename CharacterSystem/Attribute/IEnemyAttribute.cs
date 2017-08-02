using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class IEnemyAttribute : ICharacterAttribute {
        public IEnemyAttribute(IAttributeStrategy _mStrategy, int _lv, CharacterBaseAttribute _baseAttr) : base(_mStrategy, _lv, _baseAttr) {
        }
    }
}

