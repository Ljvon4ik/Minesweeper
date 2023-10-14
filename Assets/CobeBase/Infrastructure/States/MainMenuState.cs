using CobeBase.UI;
using UnityEngine;

namespace CobeBase.Infrastructure.States
{
    public class MainMenuState : IState
    {
        private GameStateMachine _gameStateMachine;
        private MainMenuView _view;

        public MainMenuState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {
            _view = Object.FindObjectOfType<MainMenuView>();
            _view.Play += Play;
        }

        public void Exit()
        {
            _view.Play -= Play;
        }
        private void Play()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }

    }
}
