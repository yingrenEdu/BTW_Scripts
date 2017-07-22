/********************************************************************
  filename: ResourcesAssetFactory
    author: Roy Zhu

   purpose: 资源加载一般分为需要实例化部分和不需要实例化部分
*********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public class ResourcesAssetFactory:IAssetFactory {
        private const string ElfPath = "Characters/Elf/";
        private const string EnemyPath = "Characters/Enemy/";
        private const string WeaponPath = "Weapons/";
        private const string EffectsPath = "Effects/";
        private const string AudiosPath = "Audios/";
        private const string SpritesPath = "Sprites/";

        public GameObject LoadElf(string _name) {
            return InstantiateGameObject(ElfPath + _name);
        }

        public GameObject LoadEnemy(string _name) {
            return InstantiateGameObject(EnemyPath + _name);
        }

        public GameObject LoadWeapon(string _name) {
            return InstantiateGameObject(WeaponPath + _name);
        }

        public GameObject LoadEffect(string _name) {
            return InstantiateGameObject(EffectsPath + _name);
        }

        public AudioClip LoadAudioClip (string _name) {
            return LoadAsset(AudiosPath + _name) as AudioClip;
        }

        public Sprite LoadSprite (string _name) {
            return LoadAsset(SpritesPath + _name) as Sprite;
        }

        private GameObject InstantiateGameObject(string _path) {
            var o = Resources.Load(_path);
            if (o == null) {
                Debug.LogError("无法加载资源,路径: " + _path);
                return null;
            }
            return UnityEngine.Object.Instantiate(o) as GameObject;
        }

        private UnityEngine.Object LoadAsset (string _path) {
            var o = Resources.Load(_path);
            if (o == null) {
                Debug.LogError("无法加载资源,路径: " + _path);
                return null;
            }
            return o;
        }
    }
}

