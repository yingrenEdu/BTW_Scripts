/********************************************************************
  filename: CharacterBuilderDirector
    author: Roy Zhu

   purpose: 角色创建指导类
*********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class CharacterBuilderDirector {
        public static ICharacter Construct (ICharacterBuilder _builder) {
            _builder.AddCharacterAttr();
            _builder.AddGameObject();
            _builder.AddWeapon();
            return _builder.GetResult();
        }
    }
}

