using System.Collections.Generic;
using System;

namespace CobeBase.Infrastructure.States
{
    public abstract class StateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;
        public StateMachine()
        {
            _states = new Dictionary<Type, IState>();
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState.Enter();
        }

        public void AddState<TState>(TState state) where TState : IState
        {
            _states.Add(typeof(TState), state);
        }
    }
}
