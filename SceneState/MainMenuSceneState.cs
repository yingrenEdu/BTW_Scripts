using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

namespace BTW.Framework {
    public class MainMenuSceneState : ISceneState {
        public MainMenuSceneState(SceneStateController _controller) : base("02MainMenuScene", _controller) {
        }

        public override void StateEnter() {
            GameObject.Find("StartButton").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
        }

        private void OnStartButtonClick() {
            mSceneStateController.SetState(new BattleSceneState(mSceneStateController));
        }
    }
}