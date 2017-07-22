using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;

namespace BTW.Game {
    public class EnemyAttackState : IEnemyState {
        public EnemyAttackState (EnemyFSMSystem _fsm, ICharacter _character) : base(_fsm, _character) {
            mStateID = EnemyStateID.Attack;
            mAttackTimer = mAttackTime;
        }

        private float mAttackTime = 1f;
        private float mAttackTimer;

        public override void Reason (List<ICharacter> _targets) {
            if (_targets == null || _targets.Count == 0) {
                mFSM.PerformTransition(EnemyTransition.NoEnemy);
                return;
            }
            float distance = Vector3.Distance(mICharacter.Position, _targets[0].Position);
            if (distance > mICharacter.AtkRange) {
                mFSM.PerformTransition(EnemyTransition.SeeEnemy);
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

