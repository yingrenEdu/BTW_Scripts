using System.Collections;
using System.Collections.Generic;
using BTW.Game;
using UnityEngine;

namespace BTW.Framework {
    public class IEnemy : ICharacter {
        protected EnemyFSMSystem mFsmSystem;

        public IEnemy () : base() {
            MakeFSM();
        }

        public void UpdateAIFSM(List<ICharacter> _targets) {
            mFsmSystem.CurrentState.Reason(_targets);
            mFsmSystem.CurrentState.Act(_targets);
        }

        private void MakeFSM () {
            mFsmSystem = new EnemyFSMSystem();

            EnemyIdleState idleState = new EnemyIdleState(mFsmSystem, this);
            idleState.AddTransition(EnemyTransition.SeeEnemy, EnemyStateID.Chase);

            EnemyChaseState chaseState = new EnemyChaseState(mFsmSystem, this);
            chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);
            chaseState.AddTransition(EnemyTransition.NoEnemy, EnemyStateID.Idle);

            EnemyAttackState attackState = new EnemyAttackState(mFsmSystem, this);
            attackState.AddTransition(EnemyTransition.SeeEnemy, EnemyStateID.Chase);
            attackState.AddTransition(EnemyTransition.NoEnemy, EnemyStateID.Idle);

            mFsmSystem.AddStates(idleState, chaseState, attackState);
        }
    }
}
