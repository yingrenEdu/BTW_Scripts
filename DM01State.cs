using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTW.Framework {
    public class DM01State : MonoBehaviour {
        private void Start() {
            Context context = new Context();
            context.SetState(new ConcreteStateA(context));

            context.Handle(11);
            context.Handle(5);
            context.Handle(20);
            context.Handle(1);
        }
    }

    public class Context {
        private IState state;

        public void SetState(IState _state) {
            state = _state;
        }

        public void Handle(int _arg) {
            state.Handle(_arg);
        }
    }

    public interface IState {
        void Handle(int _arg);
    }

    public class ConcreteStateA : IState {
        private Context context;
        public ConcreteStateA(Context _context) {
            context = _context;
        }

        public void Handle(int _arg) {
            Debug.Log("ConcreteStateA Handle " + _arg);

            if(_arg > 10) {
                context.SetState(new ConcreteStateB(context));
            }
        }
    }

    public class ConcreteStateB : IState {
        private Context context;
        public ConcreteStateB(Context _context) {
            context = _context;
        }

        public void Handle(int _arg) {
            Debug.Log("ConcreteStateB Handle " + _arg);
            if (_arg < 10) {
                context.SetState(new ConcreteStateA(context));
            }
        }
    }
}

