using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BTW.Framework {
    public abstract class ICharacter {
        protected ICharacterAttribute mICharacterAttribute;
        protected GameObject mGameObject;
        protected NavMeshAgent mNavAgent;
        protected AudioSource mAudio;
        protected IWeapon mWeapon;
        protected Animation mAnim;

        public IWeapon Weapon { set { mWeapon = value; } }

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

        public void Attack (ICharacter _target) {
            mWeapon.Fire(_target.Position);
        }

        public void PlayAnimation (string _animName) {
            mAnim.CrossFade(_animName);
        }

        public void MoveTo(Vector3 _targetPos) {
            mNavAgent.SetDestination(_targetPos);
        }
    }
}

