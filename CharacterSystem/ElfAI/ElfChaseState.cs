using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;

namespace BTW.Game {
    public class ElfChaseState : IElfState {
        public ElfChaseState (ElfFSMSystem _fsm, ICharacter _character) : base(_fsm, _character) {
            mStateID = ElfStateID.Chase;
        }

        private Vector3 mTargetPosition;
        public override void DoBeforeEnter () {
            mTargetPosition = GameFacade.Instance.GetElfTargetPosition();
        }

        public override void Reason (List<ICharacter> _targets) {
            if (_targets != null && _targets.Count > 0) {
                var dist = Vector3.Distance(mICharacter.Position, mTargetPosition);
                if (dist <= mICharacter.AtkRange)
                    mFSM.PerformTransition(ElfTransition.CanAttack);
            }
        }

        public override void Act (List<ICharacter> _targets) {
            if (_targets != null && _targets.Count > 0) {
                mICharacter.MoveTo(_targets[0].Position);
            }
            else {
                mICharacter.MoveTo(mTargetPosition);
            }
        }
    }
}

