using CobeBase.Infrastructure.States;
using CobeBase.UI;

namespace CobeBase.MainMenu
{
    public class MainMenuPresenter : IPresenter
    {
        private GameStateMachine _gameStateMachine;
        private MainMenuView _view;
        public MainMenuPresenter(GameStateMachine gameStateMachine, MainMenuView mainMenuView)
        {
            _gameStateMachine = gameStateMachine;
            _view = mainMenuView;
        }

        public void Play()
        {
            _gameStateMachine.Enter<LevelState>();
        }
    }
}
