using System.Collections;
using System.Collections.Generic;
using BTW.Framework;
using UnityEngine;

namespace BTW.Game {
    public static class FactoryManager {
        private static IAssetFactory mAssetFactory;
        private static ICharacterFactory mElfFactory;
        private static ICharacterFactory mEnemyFactory;
        private static IWeaponFactory mWeaponFactory;

        public static IAssetFactory AssetFactory {
            get { return mAssetFactory ?? (mAssetFactory = new ResourcesAssetFactory()); }
        }

        public static ICharacterFactory ElfFactory {
            get { return mElfFactory ?? (mElfFactory = new ElfFactory()); }
        }

        public static ICharacterFactory EnemyFactory {
            get { return mEnemyFactory ?? (mEnemyFactory = new ElfFactory()); }
        }

        public static IWeaponFactory WeaponFactory {
            get { return mWeaponFactory ?? (mWeaponFactory = new WeaponFactory()); }
        }
    }
}
