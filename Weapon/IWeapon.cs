using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public enum WeaponType {
        Sword,
        Bow,
    }

    public abstract class IWeapon {
        protected float mAtkPower;
        protected float mAtkRange;
        protected float mAtkPlusValue;

        protected GameObject mGameObject;
        protected ICharacter mOwner;
        protected ParticleSystem mParticle;
        protected LineRenderer mLine;
        protected Light mLight;
        protected AudioSource mAudio;

        public ICharacter Owner { set { mOwner = value; } }
        public GameObject GO { get { return mGameObject; } }

        protected float mEffectDisplayTime = 0;

        public IWeapon(float _atkPower, float _atkRange, GameObject _gameObject) {
            mAtkPower = _atkPower;
            mAtkRange = _atkRange;
            mGameObject = _gameObject;

            var effect = mGameObject.transform.Find("Effect");
            mParticle = effect.GetComponent<ParticleSystem>();
            mLine = effect.GetComponent<LineRenderer>();
            mLight = effect.GetComponent<Light>();
            mAudio = effect.GetComponent<AudioSource>();
        }

        public float AtkPower { get { return mAtkPower; } }
        public float AtkRange {
            get { return mAtkRange; }
        }

        public void Update () {
            if (mEffectDisplayTime > 0) {
                mEffectDisplayTime -= Time.deltaTime;
                if (mEffectDisplayTime <= 0) {
                    DisableEffect();
                }
            }
        }

        public void Fire (Vector3 _targetPos) {
            PlayMuzzleEffect();
            PlayBulletEffect(_targetPos);
            SetEffectDisplayTime();
            PlaySound();
        }

        /// <summary>
        /// 设置特效播放时间
        /// </summary>
        protected abstract void SetEffectDisplayTime ();

        /// <summary>
        /// 播放枪口特效
        /// </summary>
        protected virtual void PlayMuzzleEffect () {
            mParticle.Stop();
            mParticle.Play();
            mLight.enabled = true;
        }

        /// <summary>
        /// 播放子弹特效
        /// </summary>
        protected abstract void PlayBulletEffect (Vector3 _targetPos);
        protected void DoPlayBulletEffect (Vector3 _targetPos, float _width) {
            // 显示子弹轨迹特效
            mLine.enabled = true;
            mLine.startWidth = _width;
            mLine.endWidth = _width;
            mLine.SetPosition(0, mGameObject.transform.position);
            mLine.SetPosition(1, _targetPos);
        }

        protected abstract void PlaySound ();
        protected void DoPlaySound (string _name) {
            AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(_name);
            mAudio.clip = clip;
            mAudio.Play();
        }

        private void DisableEffect () {
            mLine.enabled = false;
            mLight.enabled = false;
        }
    }
}

