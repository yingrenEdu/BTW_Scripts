using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class IElf : ICharacter {
        protected ElfFSMSystem mFsmSystem;

        public IElf () : base() {
            MakeFSM();
        }

        public override void UpdateAIFSM (List<ICharacter> _targets) {
            mFsmSystem.CurrentState.Reason(_targets);
            mFsmSystem.CurrentState.Act(_targets);
        }

        private void MakeFSM () {
            mFsmSystem = new ElfFSMSystem();

            //ElfIdleState idleState = new ElfIdleState(mFsmSystem, this);
            //idleState.AddTransition(ElfTransition.SeeElf, ElfStateID.Chase);

            ElfChaseState chaseState = new ElfChaseState(mFsmSystem, this);
            chaseState.AddTransition(ElfTransition.CanAttack, ElfStateID.Attack);

            ElfAttackState attackState = new ElfAttackState(mFsmSystem, this);
            attackState.AddTransition(ElfTransition.LostEnemy, ElfStateID.Chase);

            mFsmSystem.AddStates(chaseState, attackState);
        }

        public override void UnderAttack(float _damage) {
            base.UnderAttack(_damage);

            if (mICharacterAttribute.CurrentHp <= 0) {
                
                Killed();
            }
        }
    }
}

