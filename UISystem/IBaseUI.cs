using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  BTW.Game {
    public abstract class IBaseUI {
        public virtual void Init() { }
        public virtual void Update() { }
        public virtual void Release() { }
    }
}


