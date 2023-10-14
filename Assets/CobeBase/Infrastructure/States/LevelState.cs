using CobeBase.UI;
using UnityEngine;

namespace CobeBase.Infrastructure.States
{
    public class LevelState : IState
    {
        private GameStateMachine _gameStateMachine;
        private LevelView _view;

        public LevelState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {
            _view = Object.FindObjectOfType<LevelView>();
            _view.MainMenu += Play;
        }

        public void Exit()
        {
            _view.MainMenu -= Play;
        }
        private void Play()
        {
            _gameStateMachine.Enter<LoadMainMenuState>();
        }
    }
}
