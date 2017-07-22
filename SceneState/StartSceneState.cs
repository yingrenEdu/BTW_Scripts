using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BTW.Game {
    public class StartSceneState:ISceneState {
        private Image mLogo;
        private float mSmoothTime = 1f;
        private float mWaitTime = 3f;

        public StartSceneState(SceneStateController _controller):base("01StartScene", _controller) {
        }

        public override void StateEnter() {
            mLogo = GameObject.Find("Logo").GetComponent<Image>();
            mLogo.color = Color.black;
        }

        public override void StateUpdate() {
            base.StateUpdate();
            mLogo.color = Color.Lerp(mLogo.color, Color.white, mSmoothTime * Time.deltaTime);
            mWaitTime -= Time.deltaTime;
            if (mWaitTime < 0) {
                MSceneSController.SetState(new MainMenuSceneState(MSceneSController));
            }
        }
    }
}
