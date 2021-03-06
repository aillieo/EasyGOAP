using AillieoUtils.PropLogics;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace AillieoUtils.FSM
{
    public class FSMBuilder
    {
        private IState defaultState;
        private HashSet<IState> states = new HashSet<IState>();
        private HashSet<TransitionBuilder> transitions;
        private HashSet<TransitionBuilder> anyStateTransitions;
        private IPropertyProvider customPropertyProvider;

        public FSMBuilder SetDefaultState(IState state)
        {
            defaultState = state;
            return this;
        }

        public FSMBuilder AddState(IState state)
        {
            states.Add(state);
            return this;
        }

        public FSMBuilder BindCustomPropertyProvider(IPropertyProvider propertyProvider)
        {
            this.customPropertyProvider = propertyProvider;
            return this;
        }

        public TransitionBuilder CreateTransition(IState fromState, IState toState)
        {
            if (transitions == null)
            {
                transitions = new HashSet<TransitionBuilder>();
            }

            TransitionBuilder transitionBuilder = new TransitionBuilder(fromState, toState);

            transitions.Add(transitionBuilder);

            return transitionBuilder;
        }

        public TransitionBuilder CreateTransitionFromAnyState(IState toState)
        {
            if (anyStateTransitions == null)
            {
                anyStateTransitions = new HashSet<TransitionBuilder>();
            }

            TransitionBuilder transitionBuilder = new TransitionBuilder(null, toState);

            anyStateTransitions.Add(transitionBuilder);

            return transitionBuilder;
        }

        public StateMachine ToStateMachine()
        {
            Assert.IsTrue(Validate());

            if (customPropertyProvider != null)
            {
                return new StateMachine(
                    states.OrderBy(s => s == defaultState ? 0 : 1).ToArray(),
                    transitions?.GroupBy(tr => tr.fromState).ToDictionary(pair => pair.Key, pair => pair.OrderBy(t => t.priority).Select(tb => tb.ToTransition()).ToArray()),
                    anyStateTransitions?.Select(tb => tb.ToTransition()).ToArray(),
                    customPropertyProvider);
            }
            else
            {
                return new StateMachine(
                    states.OrderBy(s => s == defaultState ? 0 : 1).ToArray(),
                    transitions?.GroupBy(tr => tr.fromState).ToDictionary(pair => pair.Key, pair => pair.OrderBy(t => t.priority).Select(tb => tb.ToTransition()).ToArray()),
                    anyStateTransitions?.Select(tb => tb.ToTransition()).ToArray());
            }
        }

        public bool Validate()
        {


            return true;
        }
    }
}
