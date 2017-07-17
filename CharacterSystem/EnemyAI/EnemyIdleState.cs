using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;

namespace BTW.Game {
    public class EnemyIdleState : IEnemyState {
        public EnemyIdleState (EnemyFSMSystem _fsm, ICharacter _character) : base(_fsm, _character) {
            mStateID = EnemyStateID.Idle;
        }

        public override void Reason(List<ICharacter> _targets) {
            if (_targets != null && _targets.Count > 0) {
                mFSM.PerformTransition(EnemyTransition.SeeEnemy);
            }
        }

        public override void Act (List<ICharacter> _targets) {
            mICharacter.PlayAnimation("stand");
        }

    }

}

