using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public static class UnityTool {
        public static GameObject FindChild (GameObject _parent, string _childName) {
            var children = _parent.GetComponentsInChildren<Transform>();
            GameObject target = null;
            bool isFound = false;

            foreach (var t in children) {
                if (t.name == _childName) {
                    if (isFound) {
                        Debug.Log(string.Format("<color=red>" + "当前物体{0}下有多个同名子物体{1}" + "</color>", _parent.name, _childName));
                        break;
                    }
                    isFound = true;
                    target = t.gameObject;
                }
            }
            return target;
        }

        public static void Attach (GameObject _parent, GameObject _child) {
            _child.transform.SetParent(_parent.transform);
            _child.transform.localPosition = Vector3.zero;
            _child.transform.localEulerAngles = Vector3.zero;
            _child.transform.localScale = Vector3.zero;
        }
    }
}

