﻿/********************************************************************
  filename: IElfAttribute
    author: Roy Zhu

   purpose: 精灵属性
*********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class IElfAttribute : ICharacterAttribute {
        public IElfAttribute(IAttributeStrategy _mStrategy, int _lv, CharacterBaseAttribute _attr) : base(_mStrategy, _lv, _attr) {
        }
    }
}

