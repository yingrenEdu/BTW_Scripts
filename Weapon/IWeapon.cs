using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
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

        public abstract void Fire(Vector3 _targetPos);
    }
}

