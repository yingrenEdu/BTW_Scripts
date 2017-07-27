using System;
using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;

namespace BTW.Game {
    public class WeaponFactory : IWeaponFactory {
        public IWeapon CreateWeapon (WeaponType _type) {
            IWeapon weapon = null;
            //string assetName = "";
            var weaopnGO = new GameObject();
            switch (_type) {
                case WeaponType.Sword:
                    //assetName = "WeaopnSword";                   
                    weaopnGO = FactoryManager.AssetFactory.LoadWeapon("WeaopnSword");
                    weapon = new WeaponSword(20, 5, weaopnGO);
                    break;
                case WeaponType.Bow:
                    //assetName = "WeaopnBow";
                    weaopnGO = FactoryManager.AssetFactory.LoadWeapon("WeaopnBow");
                    weapon = new WeaponSword(5, 20, weaopnGO);
                    break;
            }

            //var weaopnGO = factory.LoadWeapon(assetName);


            return weapon;
        }
    }
}

