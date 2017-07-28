/********************************************************************
  filename: IElfAttribute
    author: Roy Zhu

   purpose: 精灵属性
*********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class IElfAttribute : ICharacterAttribute {
        public IElfAttribute(IAttributeStrategy _mStrategy, int _lv, string _name, int _hp, float _moveSpeed, string _iconSprite, string _prefabName) : base(_mStrategy, _lv, _name, _hp, _moveSpeed, _iconSprite, _prefabName) {
        }
    }
}

