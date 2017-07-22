/********************************************************************
  filename: SceneStateController
    author: Roy Zhu

   purpose: 场景状态管理器 
*********************************************************************/

using System.Collections;
using System.Collections.Generic;
using BTW.Game;
using UnityEngine;

namespace BTW.Game {
    public class SceneStateController {
        private ISceneState mState;
        private AsyncOperation mAO;
        /// <summary>
        /// 是否已经加载过场景
        /// </summary>
        private bool mIsRunEnter;

        public void SetState(ISceneState _state, bool _isLoadScene = true) {
            if (mState != null) {
                // 设置新状态之前先退出前一个旧状态
                mState.StateExit();
            }
            mState = _state;

            if (_isLoadScene) {
                mAO = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(mState.MSceneName);
                mIsRunEnter = false;
            }
            else {
                mIsRunEnter = true;
                mState.StateEnter();
            }
        }

        public void StateUpdate() {
            if (mAO != null && mAO.isDone == false) return;

            if (mAO != null && mAO.isDone && mIsRunEnter == false) {
                mIsRunEnter = true;
                mState.StateEnter();
            }

            if (mState != null) {
                mState.StateUpdate();
            }
        }
    }
}
