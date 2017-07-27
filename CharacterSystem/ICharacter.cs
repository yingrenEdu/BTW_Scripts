using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace BTW.Game {
    public abstract class ICharacter {
        protected ICharacterAttribute mICharacterAttribute;
        protected GameObject mGameObject;
        protected NavMeshAgent mNavAgent;
        protected AudioSource mAudio;
        protected IWeapon mWeapon;
        protected Animation mAnim;

        public IWeapon Weapon {
            set {
                mWeapon = value;
                mWeapon.Owner = this;
                var child = UnityTool.FindChild(mGameObject, "weapon-point");
                UnityTool.Attach(child, mWeapon.GO);
            }
        }


        public GameObject GO {
            set {
                mGameObject = value;
                mNavAgent = mGameObject.GetComponent<NavMeshAgent>();
                mAudio = mGameObject.GetComponent<AudioSource>();
                mAnim = mGameObject.GetComponentInChildren<Animation>();
            }
        }


        public void Update() {
            mWeapon.Update();
        }

        public abstract void UpdateAIFSM(List<ICharacter> _characters);

        public Vector3 Position {
            get {
                if (mGameObject == null) {
                    Debug.LogError("mGameObject为空");
                    return Vector3.zero;
                }
                return mGameObject.transform.position;
            }
        }

        public float AtkRange {
            get { return mWeapon.AtkRange; }
        }

        /// <summary>
        /// 被攻击
        /// </summary>
        /// <param name="_damage"></param>
        public virtual void UnderAttack(float _damage) {
            mICharacterAttribute.TakeDamage(_damage);
            
            
        }

        public void Killed () { }

        public void Attack (ICharacter _target) {
            mWeapon.Fire(_target.Position);
            mGameObject.transform.LookAt(_target.Position);
            PlayAnimation("attack");
            UnderAttack(mWeapon.AtkPower + mICharacterAttribute.CritValue);
        }

        public void PlayAnimation (string _animName) {
            mAnim.CrossFade(_animName);
        }

        public void MoveTo(Vector3 _targetPos) {
            mNavAgent.SetDestination(_targetPos);
            PlayAnimation("move");
        }

        protected void DoPlaySound (string _soundName) {
            AudioClip clip = null;
            mAudio.clip = clip;
            mAudio.Play();
        }

        protected void DoPlayEffect (string _effectName) {

        }
    }
}

