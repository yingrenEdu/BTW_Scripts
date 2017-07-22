using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class BattleSceneState : ISceneState {
        public BattleSceneState(SceneStateController _controller) : base("03BattleScene", _controller) {

        }

        public override void StateEnter() {
            base.StateEnter();
            GameFacade.Instance.Init();
        }

        public override void StateUpdate() {
            base.StateUpdate();

            if (GameFacade.Instance.IsGameOver) {
                mSceneStateController.SetState(new MainMenuSceneState(mSceneStateController));
            }

            GameFacade.Instance.Update();
        }

        public override void StateExit() {
            base.StateExit();
            GameFacade.Instance.Release();
        }
    }
}