using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateStuff
{
    public class StateMachine<T>
    {
        public State<T> currentState { get; set; }
        public T owner;

        public StateMachine(T own)
        {
            owner = own;
            currentState = null;
        }

        public void ChangeState(State<T> newState)
        {
            if (currentState != null)
                currentState.ExitState(owner);
            currentState = newState;
            currentState.EnterState(owner);
        }

        public void Update()
        {
            if (currentState != null)
                currentState.UpdateState(owner);
        }
    }

    public abstract class State<T>
    {
        public abstract void EnterState(T own);
        public abstract void ExitState(T own);
        public abstract void UpdateState(T own);
    }
}
