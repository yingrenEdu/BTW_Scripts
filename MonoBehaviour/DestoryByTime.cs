using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class DestoryByTime : MonoBehaviour {
        public float time;
        void Start () {
            Invoke("Destory", time);
        }

        void Destory() {
            DestroyImmediate(this);
        }
    }
}


