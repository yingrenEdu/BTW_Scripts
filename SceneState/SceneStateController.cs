using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public class SceneStateController {
        private ISceneState state;
        private AsyncOperation ao;
        /// <summary>
        /// 是否已经加载过场景
        /// </summary>
        private bool isRunEnter;

        public void SetState(ISceneState _state, bool _isLoadScene = true) {
            if (state != null) {
                state.StateExit();
            }
            state = _state;

            if (_isLoadScene) {
                ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(state.SceneName);
                isRunEnter = false;
            }
            else {
                isRunEnter = true;
                state.StateEnter();
            }
        }

        public void StateUpdate() {
            if (ao != null && ao.isDone == false) return;

            if (ao != null && ao.isDone && isRunEnter == false) {
                isRunEnter = true;
                state.StateEnter();
            }

            if (state != null) {
                state.StateUpdate();
            }
        }
    }
}
