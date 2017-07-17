using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public enum ElfTransition {
        NullTransition = 0,
        SeeEnemy,
        LostEnemy,
        CanAttack
    }

    public enum ElfStateID {
        NullState,
        Idle,
        Chase,
        Attack
    }

    public abstract class IElfState {
        protected Dictionary<ElfTransition, ElfStateID> mMap = new Dictionary<ElfTransition, ElfStateID>();
        protected ElfStateID mStateID;
        protected ICharacter mICharacter;
        protected ElfFSMSystem mFSM;

        protected IElfState (ElfFSMSystem _fsm, ICharacter _character) {
            mFSM = _fsm;
            mICharacter = _character;
        }

        public ElfStateID StateID { get { return mStateID; } }

        public void AddTransition (ElfTransition _trans, ElfStateID _id) {
            if (_trans == ElfTransition.NullTransition) {
                Debug.LogError("ElfTransition Error : Trans不能为空");
                return;
            }
            if (_id == ElfStateID.NullState) {
                Debug.LogError("ElfStateID Error: 状态ID不能为空");
                return;
            }
            if (mMap.ContainsKey(_trans)) {
                Debug.LogError("ElfTransition Error: " + _trans + "已经添加上了");
                return;
            }

            mMap.Add(_trans, _id);
        }

        public void DeleteTransition (ElfTransition _trans) {
            if (mMap.ContainsKey(_trans) == false) {
                Debug.LogError("删除转换条件的时候，转换条件: [" + _trans + "] 不存在");
                return;
            }
            mMap.Remove(_trans);
        }

        public ElfStateID GetOutputState (ElfTransition _trans) {
            if (mMap.ContainsKey(_trans) == false) {
                return ElfStateID.NullState;
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

