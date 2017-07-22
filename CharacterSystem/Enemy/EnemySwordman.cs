using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;

namespace BTW.Game {
    public class EnemySwordman : IEnemy {
        protected override void PlaySound() {
            DoPlaySound("");
        }

        protected override void PlayEffect() {
            DoPlayEffect("");
        }
    }
}

