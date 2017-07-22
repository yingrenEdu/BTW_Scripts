using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Game {
    public class CharacterSystem : IGameSystem {
        private List<ICharacter> mEnemys = new List<ICharacter>();
        private List<ICharacter> mElfs = new List<ICharacter>();

        public override void Update () {
            UpdateEnemy();
            UpdateElf();
        }

        public void AddEnemy (IEnemy _enemy) {
            mEnemys.Add(_enemy);
        }

        public void RemoveEnemy (IEnemy _enemy) {
            mEnemys.Remove(_enemy);
        }

        public void AddElf (IElf _elf) {
            mElfs.Add(_elf);
        }

        public void RemoveElf (IElf _elf) {
            mElfs.Remove(_elf);
        }

        private void UpdateEnemy() {
            foreach (var e in mEnemys) {
                e.UpdateAIFSM(mElfs);
                e.Update();
            }
        }

        private void UpdateElf() {
            foreach (var e in mElfs) {
                e.UpdateAIFSM(mEnemys);
                e.Update();
            }
        }
    }
}

