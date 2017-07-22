using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  BTW.Framework {
    public interface IAssetFactory {
        GameObject LoadElf(string _name);
        GameObject LoadEnemy(string _name);
        GameObject LoadWeapon(string _name);
        GameObject LoadEffect(string _name);
        AudioClip LoadAudioClip (string _name);
        Sprite LoadSprite (string _name);
    }
}
