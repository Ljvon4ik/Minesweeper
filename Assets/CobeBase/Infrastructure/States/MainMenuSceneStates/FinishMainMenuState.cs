﻿using Cysharp.Threading.Tasks;

namespace CobeBase.Infrastructure.States.MainMenuSceneStates
{
    public class FinishMainMenuState : IState
    {
        private GameStateMachine _gameStateMachine;
        public FinishMainMenuState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;        
        }

        public void Enter()
        {
            _gameStateMachine.Enter<LevelState>();
        }

        public void Exit()
        {
        }
    }
}
