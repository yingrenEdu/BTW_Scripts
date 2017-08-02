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
            var attr = FactoryManager.AttrFactory.GetWeaponBaseAttribute(_type);
            switch (_type) {
                case WeaponType.Sword:
                    //assetName = "WeaopnSword";                   
                    weaopnGO = FactoryManager.AssetFactory.LoadWeapon("WeaopnSword");
                    weapon = new WeaponSword(attr, weaopnGO);
                    break;
                case WeaponType.Bow:
                    //assetName = "WeaopnBow";
                    weaopnGO = FactoryManager.AssetFactory.LoadWeapon("WeaopnBow");
                    weapon = new WeaponBow(attr, weaopnGO);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("_type", _type, null);
            }
            //var weaopnGO = factory.LoadWeapon(assetName);

            return weapon;
        }
    }
}

