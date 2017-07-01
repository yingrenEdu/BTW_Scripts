/********************************************************************
  filename: GameFacade
    author: Roy Zhu

   purpose: 游戏管理类
*********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public class GameFacade {
        private static GameFacade mInstance = new GameFacade();
        public static GameFacade Instance { get { return mInstance; } }

        public bool IsGameOver { get; set; }

        private GameFacade() { }

        #region 内部子系统
        private AchievementSystem mAchievementSystem;
        private CampSystem mCampSystem;
        private CharacterSystem mCharacterSystem;
        private GameEventSystem mGameEventSystem;
        private StageSystem mStageSystem;

        private GamePauseUI mGamePauseUI;
        private GameStateInfoUI mGameStateInfoUI;
        private SoldierInfoUI mSoldierInfoUI;
        #endregion

        public void Init() {
            mAchievementSystem = new AchievementSystem(); ;
            mCampSystem = new CampSystem();
            mCharacterSystem = new CharacterSystem();
            mGameEventSystem = new GameEventSystem();
            mStageSystem = new StageSystem();

            mGamePauseUI = new GamePauseUI();
            mGameStateInfoUI = new GameStateInfoUI();
            mSoldierInfoUI = new SoldierInfoUI();

            mAchievementSystem.Init();
            mCampSystem.Init();
            mCharacterSystem.Init();
            mGameEventSystem.Init();
            mStageSystem.Init();
            mGamePauseUI.Init();
            mGameStateInfoUI.Init();
            mSoldierInfoUI.Init();
        }

        public void Update() {
            mAchievementSystem.Update();
            mCampSystem.Update();
            mCharacterSystem.Update();
            mGameEventSystem.Update();
            mStageSystem.Update();
            mGamePauseUI.Update();
            mGameStateInfoUI.Update();
            mSoldierInfoUI.Update();
        }

        public void Release() {
            mAchievementSystem.Release();
            mCampSystem.Release();
            mCharacterSystem.Release();
            mGameEventSystem.Release();
            mStageSystem.Release();
            mGamePauseUI.Release();
            mGameStateInfoUI.Release();
            mSoldierInfoUI.Release();
        }
    }
}

