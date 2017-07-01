using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public class ISceneState {
        private string mSceneName;
        protected SceneStateController mSceneStateController;
        protected SceneStateController MSceneSController {
            get { return mSceneStateController; }
        }

        public string MSceneName {
            get { return mSceneName; }
        }

        public ISceneState(string _mSceneName, SceneStateController _controller) {
            mSceneName = _mSceneName;
            mSceneStateController = _controller;
        }

        public virtual void StateEnter() {
        }

        public virtual void StateUpdate() {
        }

        public virtual void StateExit() {
        }
    }
}

