using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public enum EnemyTransition {
        NullTransition = 0,
        SeeEnemy,
        NoEnemy,
        CanAttack
    }

    public enum EnemyStateID {
        NullState,
        Idle,
        Chase,
        Attack
    }

    public abstract class IEnemyState {
        protected Dictionary<EnemyTransition, EnemyStateID> mMap = new Dictionary<EnemyTransition, EnemyStateID>();
        protected EnemyStateID mStateID;
        protected ICharacter mICharacter;
        protected EnemyFSMSystem mFSM;

        protected IEnemyState (EnemyFSMSystem _fsm, ICharacter _character) {
            mFSM = _fsm;
            mICharacter = _character;
        }

        public EnemyStateID StateID { get { return mStateID; } }

        public void AddTransition (EnemyTransition _trans, EnemyStateID _id) {
            if (_trans == EnemyTransition.NullTransition) {
                Debug.LogError("EnemyTransition Error : Trans不能为空");
                return;
            }
            if (_id == EnemyStateID.NullState) {
                Debug.LogError("EnemyStateID Error: 状态ID不能为空");
                return;
            }
            if (mMap.ContainsKey(_trans)) {
                Debug.LogError("EnemyTransition Error: " + _trans + "已经添加上了");
                return;
            }

            mMap.Add(_trans, _id);
        }

        public void DeleteTransition (EnemyTransition _trans) {
            if (mMap.ContainsKey(_trans) == false) {
                Debug.LogError("删除转换条件的时候，转换条件: [" + _trans + "] 不存在");
                return;
            }
            mMap.Remove(_trans);
        }

        public EnemyStateID GetOutputState (EnemyTransition _trans) {
            if (mMap.ContainsKey(_trans) == false) {
                return EnemyStateID.NullState;
            }
            else {
                return mMap[_trans];
            }
        }

        public virtual void DoBeforeEnter () { }
        public virtual void DoBeforeLeave () { }

        /// <summary>
        /// 判断什么情况下需要转换
        /// </summary>
        public abstract void Reason (List<ICharacter> _targets);
        public abstract void Act (List<ICharacter> _targets);
    }
}
