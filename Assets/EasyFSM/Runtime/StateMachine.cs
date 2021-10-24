using System;
using System.Collections.Generic;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace AillieoUtils.FSM
{
    public class StateMachine
    {
        internal readonly IState[] states;
        internal readonly Dictionary<IState, Transition[]> transitions;
        internal readonly Transition[] anyStateTransitions;

        internal readonly IPropertyProvider properties;

        private IState currentState;

        internal StateMachine(IState[] states, Dictionary<IState, Transition[]> transitions, Transition[] anyStateTransitions)
            : this(states, transitions, anyStateTransitions, new PropertyProvider())
        {
        }

        internal StateMachine(IState[] states, Dictionary<IState, Transition[]> transitions, Transition[] anyStateTransitions, IPropertyProvider customPropertyProvider)
        {
            this.states = states;
            this.transitions = transitions;
            this.anyStateTransitions = anyStateTransitions;
            this.properties = customPropertyProvider;
        }

        public int GetInt(string key)
        {
            return properties.Get(key);
        }

        public float GetFloat(string key)
        {
            return properties.Get(key);
        }

        public bool GetBool(string key)
        {
            return properties.Get(key);
        }

        public void SetInt(string key, int value)
        {
            properties.Set(key, value);
        }

        public void SetFloat(string key, float value)
        {
            properties.Set(key, value);
        }

        public void SetBool(string key, bool value)
        {
            properties.Set(key, value);
        }

        public IPropertyProvider GetAssociatedProperties()
        {
            return properties;
        }

        public IState GetCurrentState()
        {
            return currentState;
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
                currentState.OnEnter(this);
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
                            if (t.toState == currentState)
                            {
                                continue;
                            }

                            if (t.CheckCondition(this))
                            {
                                hasTransition = true;
                                currentState.OnExit(this);
                                currentState = t.toState;
                                currentState.OnEnter(this);
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
                        if (t.toState == currentState)
                        {
                            continue;
                        }

                        if (t.CheckCondition(this))
                        {
                            hasTransition = true;
                            currentState.OnExit(this);
                            currentState = t.toState;
                            currentState.OnEnter(this);
                        }
                    }
                }
            }

            if (!hasTransition)
            {
                currentState.OnUpdate(this, deltaTime);
            }
        }

        public void CleanUp()
        {
            if (currentState != null)
            {
                currentState.OnExit(this);
                currentState = null;
            }
        }
    }
}
