using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class ElfFSMSystem {
        private List<IElfState> mStates = new List<IElfState>();
        private IElfState mCurrentState;
        public IElfState CurrentState { get { return mCurrentState; } }

        public void AddStates (params IElfState[] _states) {
            foreach (var state in _states) {
                AddState(state);
            }
        }
        public void AddState (IElfState _state) {
            if (_state == null) {
                Debug.LogError("要添加的状态为空"); return;
            }
            if (mStates.Count == 0) {
                mStates.Add(_state);
                mCurrentState = _state;
                mCurrentState.DoBeforeEnter();
                return;
            }
            foreach (var v in mStates) {
                if (v.StateID == _state.StateID) {
                    Debug.LogError("要添加的状态机ID： [" + _state.StateID + "]已经添加");
                    return;
                }
            }
            mStates.Add(_state);
        }

        public void DeleteState (ElfStateID _stateID) {
            if (_stateID == ElfStateID.NullState) {
                Debug.LogError("所要删除的状态机ID为空： [" + _stateID + "]");
                return;
            }
            foreach (var v in mStates) {
                if (v.StateID == _stateID) {
                    mStates.Remove(v);
                    return;
                }
            }
            Debug.LogError("所要删除的状态机ID不存在与集合中： [" + _stateID + "]");
        }

        /// <summary>
        /// 执行状态转变
        /// </summary>
        /// <param name="_trans"></param>
        public void PerformTransition (ElfTransition _trans) {
            if (_trans == ElfTransition.NullTransition) {
                Debug.LogError("要执行的转换条件为空： " + _trans);
                return;
            }
            var stateID = mCurrentState.GetOutputState(_trans);
            if (stateID == ElfStateID.NullState) {
                Debug.LogError("在转换条件 [" + _trans + "] 下，没有对应的转换状态");
                return;
            }
            foreach (var v in mStates) {
                if (v.StateID == stateID) {
                    mCurrentState.DoBeforeLeave();
                    mCurrentState = v;
                    v.DoBeforeEnter();
                    return;
                }
            }
        }
    }
}

