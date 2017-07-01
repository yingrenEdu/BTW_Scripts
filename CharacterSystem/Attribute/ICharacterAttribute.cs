using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public class ICharacterAttribute {
        protected string mName;
        protected float mMaxHP;
        protected float mMoveSpeed;
        protected float mCurrentHP;
        protected string mIconSprite;

        protected int mLevel;
        /// <summary>
        /// 暴击率
        /// </summary>
        protected float mCritRate;

        protected IAttributeStrategy mStrategy;
    }
}
