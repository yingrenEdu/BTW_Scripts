using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;

namespace BTW.Game {
    public class ElfAttackState : IElfState {
        private float mAttackTime = 1f;
        private float mAttackTimer;

        public ElfAttackState (ElfFSMSystem _fsm, ICharacter _character) : base(_fsm, _character) {
            mStateID = ElfStateID.Attack;
            mAttackTimer = mAttackTime;
        }

        public override void Reason (List<ICharacter> _targets) {
            if (_targets == null || _targets.Count == 0) {
                mFSM.PerformTransition(ElfTransition.LostEnemy);
            }
            else {
                var dist = Vector3.Distance(mICharacter.Position, _targets[0].Position);
                if (dist > mICharacter.AtkRange)
                    mFSM.PerformTransition(ElfTransition.LostEnemy);
            }
        }

        public override void Act (List<ICharacter> _targets) {
            if (_targets == null || _targets.Count == 0) return;
            mAttackTimer += Time.deltaTime;
            if (mAttackTimer >= mAttackTime) {
                mAttackTimer = 0;
                mICharacter.Attack(_targets[0]);
            }
        }
    }
}


