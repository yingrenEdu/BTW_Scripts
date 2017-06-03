using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public class GameLoop : MonoBehaviour {
        private SceneStateController sceneStateController;

        private void Awake() {
            DontDestroyOnLoad(this.gameObject);
        }

        void Start() {
            sceneStateController = new SceneStateController();
            sceneStateController.SetState(new StartSceneState(sceneStateController), false);
        }

        void Update() {
            sceneStateController.StateUpdate();
        }
    }
}


