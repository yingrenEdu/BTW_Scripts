/********************************************************************
  filename: IAttributeFactory
    author: Roy Zhu

   purpose: 属性工厂接口
*********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public interface IAttributeFactory {
        CharacterBaseAttribute GetCharacterBaseAttribute (System.Type _t);
        WeaponBaseAttribute GetWeaponBaseAttribute (WeaponType _type);
    }
}


