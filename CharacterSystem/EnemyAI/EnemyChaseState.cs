using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;

public class EnemyChaseState : IEnemyState {
    public EnemyChaseState(EnemyFSMSystem _fsm, ICharacter _character) : base(_fsm, _character) {
        mStateID = EnemyStateID.Chase;
    }

    public override void Reason(List<ICharacter> _targets) {
        if (_targets == null || _targets.Count == 0) {
            mFSM.PerformTransition(EnemyTransition.NoEnemy);
            return;
        }
        float distance = Vector3.Distance(_targets[0].Position, mICharacter.Position);
        if (distance <= mICharacter.AtkRange) {
            mFSM.PerformTransition(EnemyTransition.CanAttack);
        }
    }

    public override void Act(List<ICharacter> _targets) {
        if (_targets != null && _targets.Count > 0) {
            mICharacter.MoveTo(_targets[0].Position);
        }
    }
}
