using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public class ISceneState {
        private string sceneName;
        private SceneStateController sceneStateController;
        protected SceneStateController SSController {
            get { return sceneStateController; }
        }

        public string SceneName {
            get { return sceneName; }
        }

        public ISceneState(string _sceneName, SceneStateController _controller) {
            sceneName = _sceneName;
            sceneStateController = _controller;
        }

        public virtual void StateEnter() {
        }

        public virtual void StateUpdate() {
        }

        public virtual void StateExit() {
        }
    }
}

