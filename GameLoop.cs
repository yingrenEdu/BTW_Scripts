using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public class GameLoop : MonoBehaviour {
        private SceneStateController mSceneStateController;

        private void Awake() {
            DontDestroyOnLoad(this.gameObject);
        }

        void Start() {
            mSceneStateController = new SceneStateController();
            mSceneStateController.SetState(new StartSceneState(mSceneStateController), false);
        }

        void Update() {
            mSceneStateController.StateUpdate();
        }
    }
}


