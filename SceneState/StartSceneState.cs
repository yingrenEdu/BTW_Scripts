using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BTW.Framework {
    public class StartSceneState:ISceneState {
        private Image logo;
        private float smoothTime = 1f;
        private float waitTime = 3f;

        public StartSceneState(SceneStateController _controller):base("01StartScene", _controller) {
        }

        public override void StateEnter() {
            logo = GameObject.Find("Logo").GetComponent<Image>();
            logo.color = Color.black;
        }

        public override void StateUpdate() {
            base.StateUpdate();
            logo.color = Color.Lerp(logo.color, Color.white, smoothTime * Time.deltaTime);
            waitTime -= Time.deltaTime;
            if (waitTime < 0) {
                SSController.SetState(new MainMenuSceneState(SSController));
            }
        }
    }
}
