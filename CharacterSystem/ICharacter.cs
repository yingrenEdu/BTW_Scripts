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

        public IWeapon Weapon { set { mWeapon = value; } }

        public void Attack(Vector3 _targetPosition) {
            mWeapon.Fire(_targetPosition);
        }
    }
}

