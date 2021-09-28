using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.FSM
{
    public class StateMachine
    {
        internal readonly IState[] states;
        internal readonly Dictionary<IState, Transition[]> transitions;
        internal readonly Transition[] anyStateTransitions;

        internal readonly Dictionary<string, float> parameters;

        private IState currentState;

        internal StateMachine(IState[] states, Dictionary<IState, Transition[]> transitions, Transition[] anyStateTransitions)
        {

        }

        public void Init()
        {
            if (currentState != null)
            {
                throw new Exception();
            }

            if (states != null && states.Length > 0)
            {
                currentState = states[0];
                currentState.OnEnter();
            }
        }

        public void Update(float deltaTime)
        {
            bool hasTransition = false;
            if (transitions != null)
            {
                if (transitions.TryGetValue(currentState, out Transition[] trans))
                {
                    if (trans != null)
                    {
                        foreach (Transition t in trans)
                        {
                            if (t.CheckCondition())
                            {
                                hasTransition = true;
                                currentState.OnExit();
                                currentState = t.toState;
                                currentState.OnEnter();
                            }
                        }
                    }
                }
            }

            if (!hasTransition)
            {
                if (anyStateTransitions != null)
                {
                    foreach (Transition t in anyStateTransitions)
                    {
                        if (t.CheckCondition())
                        {
                            hasTransition = true;
                            currentState.OnExit();
                            currentState = t.toState;
                            currentState.OnEnter();
                        }
                    }
                }
            }

            if (!hasTransition)
            {
                currentState.OnUpdate(deltaTime);
            }
        }

        public void CleanUp()
        {
            if (currentState != null)
            {
                currentState.OnExit();
                currentState = null;
            }
        }
    }
}
